﻿using LiveCharts;
using LiveCharts.Wpf;
using Project.Data;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Control
{
    class ControlDashboard
    {
        LocalDatabase database;

        private ObservableCollection<Incoming> Incomings { get; set; }
        private ObservableCollection<Expense> Expenses { get; set; }
        
        public ControlDashboard()
        {
            database = LocalDatabase.GetInstance();

            Incomings = database.GetIncomings();
            Expenses = database.GetExpenses();

        }

        public List<Account> GetAccountList()
        {
            return database.GetAccounts().Where(a => a.Enabled).OrderByDescending(a => a.Amount).ToList();
        }

        public List<ItemChartMonthly> GetItensChartMonthly()
        {
            var accounts = GetAccountList().Where(a => a.Enabled.Equals(true));
            List<ItemChartMonthly> itemCharts = new List<ItemChartMonthly>();

            List<Incoming> selectedIncomings = new List<Incoming>();
            foreach (var item in Incomings)
            {
                var itemAccount = item.Account.Name;
                var accountEnabled = accounts.Where(a => a.Name.Equals(itemAccount)).FirstOrDefault();
                if (accountEnabled != null)
                    selectedIncomings.Add(item);
            }

            var groupedIncomings = (from i in selectedIncomings
                                    group i by new { month = i.Date.Month, year = i.Date.Year } into d
                                    select new
                                    {
                                        dt = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                                        count = d.Count()
                                    }).OrderByDescending(g => g.dt);

            List<Expense> selectedExpenses = new List<Expense>();
            foreach (var item in Expenses)
            {
                var itemAccount = item.Account.Name;
                var accountEnabled = accounts.Where(a => a.Name.Equals(itemAccount)).FirstOrDefault();
                if (accountEnabled != null)
                    selectedExpenses.Add(item);
            }

            var groupedExpenses = (from e in selectedExpenses
                                   group e by new { month = e.Date.Month, year = e.Date.Year } into d
                                   select new
                                   {
                                       dt = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                                       count = d.Count()
                                   }).OrderByDescending(g => g.dt);

            foreach (var item in groupedIncomings)
            {
                var ic = itemCharts.Where(i => i.Date.Equals(DateTime.Parse("01/" + item.dt))).FirstOrDefault();
                if (ic == null)
                {
                    ic = new ItemChartMonthly(item.dt);
                    itemCharts.Add(ic);
                }
                ic.SetIncoming(selectedIncomings.Where(i => i.Date.Month.Equals(ic.Date.Month) && i.Date.Year.Equals(ic.Date.Year)).Sum(i => i.Value));
            }

            foreach (var item in groupedExpenses)
            {
                var ic = itemCharts.Where(i => i.Date.Equals(DateTime.Parse("01/" + item.dt))).FirstOrDefault();

                if (ic == null)
                {
                    ic = new ItemChartMonthly(item.dt);
                    itemCharts.Add(ic);
                }
                ic.SetExpense(selectedExpenses.Where(e => e.Date.Month.Equals(ic.Date.Month) && e.Date.Year.Equals(ic.Date.Year)).Sum(e => e.Value));
            }

            return itemCharts.OrderByDescending(i => i.Date).ToList();
        }

        internal List<MonthlyIncome> GetMonthlyIncomes()
        {
            var accounts = GetAccountList().Where(a => a.Enabled.Equals(true));
            List<MonthlyIncome> itemsChart = new List<MonthlyIncome>();

            List<Incoming> selectedIncomings = new List<Incoming>();
            foreach (var item in Incomings)
            {
                var itemAccount = item.Account.Name;
                var accountEnabled = accounts.Where(a => a.Name.Equals(itemAccount)).FirstOrDefault();
                if (accountEnabled != null)
                    selectedIncomings.Add(item);
            }

            var groupedIncomings = (from i in selectedIncomings
                                    where i.Category != null && i.Category.Name.Equals("Производительность")
                                    group i by new { month = i.Date.Month, year = i.Date.Year } into d
                                    select new
                                    {
                                        dt = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                                        count = d.Count()
                                    }).OrderByDescending(g => g.dt);

            foreach (var item in groupedIncomings)
            {
                var ic = itemsChart.Where(i => i.Date.Equals(DateTime.Parse("01/" + item.dt))).FirstOrDefault();
                if (ic == null)
                {
                    ic = new MonthlyIncome(item.dt);
                    itemsChart.Add(ic);
                }
                ic.SetIncoming(selectedIncomings.Where(i => i.Date.Month.Equals(ic.Date.Month) &&
                                                i.Date.Year.Equals(ic.Date.Year) &&
                                                i.Category != null &&
                                                i.Category.Name.Equals("Производительность")).Sum(i => i.Value));
            }

            return itemsChart.OrderByDescending(i => i.Date).ToList();
        }

        public List<ItemChartCategory> GetItensChartCategories()
        {
            var accounts = GetAccountList().Where(a => a.Enabled.Equals(true));
            List<ItemChartCategory> itemCharts = new List<ItemChartCategory>();

            List<Expense> selectedExpenses = new List<Expense>();
            foreach (var item in Expenses)
            {
                var itemAccount = item.Account.Name;
                var accountEnabled = accounts.Where(a => a.Name.Equals(itemAccount)).FirstOrDefault();
                if (accountEnabled != null)
                    selectedExpenses.Add(item);
            }

            var groupedExpenses = (from e in selectedExpenses
                                   group e by new { month = e.Date.Month, year = e.Date.Year } into d
                                   select new
                                   {
                                       dt = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                                       count = d.Count()
                                   }).OrderByDescending(g => g.dt);

            foreach (var item in groupedExpenses)
            {
                var ic = itemCharts.Where(i => i.Date.Equals(DateTime.Parse("01/" + item.dt))).FirstOrDefault();
                if (ic == null)
                {
                    ic = new ItemChartCategory(item.dt);
                    itemCharts.Add(ic);
                }

                List<string> groups = (from g in selectedExpenses
                                       where g.Category != null && g.Date.Month.Equals(ic.Date.Month) && g.Date.Year.Equals(ic.Date.Year)
                                       select g.Category.Group).Distinct().ToList();

                foreach (var group in groups)
                {
                    var value = selectedExpenses.Where(i => i.Category != null && i.Date.Month.Equals(ic.Date.Month) && i.Date.Year.Equals(ic.Date.Year) && i.Category.Group.Equals(group)).Sum(g => g.Value);
                    ic.SetSeries(group, value);
                }
            }

            return itemCharts.OrderByDescending(i => i.Date).ToList();
        }

       

        public List<ItemTimeLine> GetTransactionsTimeLine()
        {
            ObservableCollection<ItemTimeLine> itl = new ObservableCollection<ItemTimeLine>();

            foreach (var item in Incomings)
            {
                itl.Add(new ItemTimeLine("incoming", item.Description, item.Value.ToString("C"), item.Date));
            }

            foreach (var item in Expenses)
            {
                itl.Add(new ItemTimeLine("expense", item.Description, item.Value.ToString("C"), item.Date));
            }

           

            return itl.OrderByDescending(i => i.Date).ToList();
        }
    }
}
