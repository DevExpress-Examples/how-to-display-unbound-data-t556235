using DevExpress.Data;
using System;
using Windows.UI.Xaml.Controls;


namespace Unbound_Columns {
    public sealed partial class MainPage : Page
    {
        public MainPage() {
            this.InitializeComponent();
            grid.ItemsSource = new ProductList();
            grid.TotalSummary.AddItem(SummaryItemType.Count, "ProductName");
            grid.TotalSummary.AddItem(SummaryItemType.Max, "UnitPrice").DisplayFormat = "Max: {0:c2}";
            grid.TotalSummary.AddItem(SummaryItemType.Average, "UnitPrice").DisplayFormat = "Avg: {0:c2}";
        }

        private void grid_CustomUnboundColumnData(object sender, DevExpress.UI.Xaml.Grid.GridColumnDataEventArgs e) {
            if (e.IsGetData) {
                double price = Convert.ToDouble(e.GetListSourceFieldValue("UnitPrice"));
                double quantity = Convert.ToDouble(e.GetListSourceFieldValue("Quantity"));
                e.Value = price * quantity;
            }
        }

    }
}
