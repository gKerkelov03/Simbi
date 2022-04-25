using Simbi.Common;
using Simbi.Mappings;
using Simbi.Services;
using Simbi.Services.Data.Contracts;
using Simbi.Services.Models;
using Simbi.WindowsForms.Infrastructure;
using Simbi.WindowsForms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class CashierPage : Form
{
    private readonly UserManager userManager;
    private readonly Redirector redirector;
    private readonly IMaterialsService materialsService;
    private readonly IOrdersService ordersService;
    private readonly IAdminRemarksService adminRemarksService;

    private OrderServiceModel currentOrder;
    private MaterialViewModel currentSelectedMaterial;
    private bool shouldEnterUserInfoFlag = false;
    public CashierPage(UserManager UserManager, Redirector redirector, IMaterialsService materialsService, IOrdersService ordersService, IAdminRemarksService adminRemarksService)
    {
        this.userManager = UserManager;
        this.redirector = redirector;
        this.materialsService = materialsService;
        this.ordersService = ordersService;
        this.adminRemarksService = adminRemarksService;

        this.currentOrder = new OrderServiceModel();

        InitializeComponent();
    }

    private async void CashierPage_Load(object sender, EventArgs e)
    {
        this.titleLabel.Text = "Keep up the good work " + this.userManager.CurrentUserUsername();

        SetUpDataGridView<PurchaseViewModel>(this.purchasesDataGridView, this.currentOrder.Purchases, DataGridViewCRUDOption.Delete | DataGridViewCRUDOption.Create | DataGridViewCRUDOption.Update);
        AddColumnToDataGridView(this.purchasesDataGridView, "Delete", "Delete");
        this.purchasesDataGridView.Columns["MaterialName"].ReadOnly = true;
        this.purchasesDataGridView.Columns["MaterialPrice"].Visible = false;
        this.purchasesDataGridView.CellEndEdit += PurchasesDataGridViewEditHandler;


        SetUpDataGridView<MaterialViewModel>(this.materialsDataGridView, await this.materialsService.GetAll(material => !material.IsDeleted));
        this.materialsDataGridView.RowStateChanged += PurchaseDataGridViewRowStateChangeHandler;
        foreach (var row in this.materialsDataGridView.SelectedRows)
        {
            this.currentSelectedMaterial = ((DataGridViewRow)row).DataBoundItem.To<MaterialViewModel>();
            this.materialTextBox.Text = this.currentSelectedMaterial.Name;
        }


        SetUpDataGridView<AdminRemarkViewModel>(this.adminRemarksDataGridView, await this.adminRemarksService.GetAll(remark => remark.Creator.Username == this.userManager.CurrentUserUsername()), DataGridViewCRUDOption.Delete | DataGridViewCRUDOption.Create | DataGridViewCRUDOption.Update);
        AddColumnToDataGridView(this.adminRemarksDataGridView, "Delete", "Delete");
        this.adminRemarksDataGridView.Columns["CreatorUsername"].Visible = false;
        this.adminRemarksDataGridView.UserAddedRow += AdminRemarksDataGridViewAddHandler;
        this.adminRemarksDataGridView.CellEndEdit += AdminRemarksDataGridViewEditHandler;
    }
    private void PurchaseDataGridViewRowStateChangeHandler(object sender, DataGridViewRowStateChangedEventArgs e)
    {

        //Todo: see why this does not work
        // var row = this.materialsDataGridView.SelectedRows.First();

        foreach (var row in this.materialsDataGridView.SelectedRows)
        {
            this.currentSelectedMaterial = ((DataGridViewRow)row).DataBoundItem.To<MaterialViewModel>();
            this.materialTextBox.Text = this.currentSelectedMaterial.Name;
        }
    }

    private async void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var senderGrid = (DataGridView)sender;

        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn buttonColumn && e.RowIndex >= 0)
        {
            if (buttonColumn.Text == "Delete" && senderGrid == this.adminRemarksDataGridView)
            {
                await this.adminRemarksService.DeleteById(new Guid(senderGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()));
            }

            senderGrid.Rows.RemoveAt(e.RowIndex);
        }
    }

    private void AdminRemarksDataGridViewAddHandler(object sender, DataGridViewRowEventArgs e) => this.adminRemarksService.Add(((DataGridView)sender).Rows[e.Row.Index - 1].DataBoundItem.To<AdminRemarkServiceModel>());
    private void AdminRemarksDataGridViewEditHandler(object sender, DataGridViewCellEventArgs e) => this.adminRemarksService.Update(((DataGridView)sender).Rows[e.RowIndex].DataBoundItem.To<AdminRemarkServiceModel>());
    private void PurchasesDataGridViewEditHandler(object sender, DataGridViewCellEventArgs e)
    {
        var senderGrid = (DataGridView)sender;

        if(senderGrid.Columns[e.ColumnIndex].HeaderText == "QuantityInKilograms")
        {
            double oldQuantity = (double)senderGrid.Rows[e.RowIndex].Cells["Price"].Value / (double)senderGrid.Rows[e.RowIndex].Cells["MaterialPrice"].Value;
            double newQuantity = double.Parse(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            var materialPrice = (double)senderGrid.Rows[e.RowIndex].Cells["MaterialPrice"].Value;
            var purchasePrice = newQuantity * materialPrice;
            senderGrid.Rows[e.RowIndex].Cells["Price"].Value = purchasePrice;

            var total = double.Parse(this.TotalOrderPriceTextBox.Text.Replace("Total:", string.Empty).Trim()) + purchasePrice - (oldQuantity * materialPrice);
            this.TotalOrderPriceTextBox.Text = "Total: " + total.ToString();
        }        
    }

    private void RefreshButtonClick(object sender, EventArgs e) => CashierPage_Load(null, null);
    private void SignOutButtonClick(object sender, EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }
    private void ConfirmOrderButtonClick(object sender, EventArgs e)
    {
        if (shouldEnterUserInfoFlag)
        {
            var clientInfo = this.TotalOrderPriceTextBox.Text.Replace("Client info: ", string.Empty).Trim().Split(new[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.currentOrder.ClientName = clientInfo[0];
            this.currentOrder.ClientPhoneNumber = clientInfo[1];

            this.ordersService.Add(this.currentOrder);
            this.currentOrder = new OrderServiceModel();

            this.shouldEnterUserInfoFlag = false;
            this.confirmOrderButton.Text = "Confirm";
            this.TotalOrderPriceTextBox.Text = "Total: ";
            this.TotalOrderPriceTextBox.Enabled = false;
        }
        else
        {
            var currentPurchases = this.purchasesDataGridView.DataSource;
            this.currentOrder.Purchases = (currentPurchases as ICollection).To<PurchaseServiceModel>().ToList();
            
            this.purchasesDataGridView.DataSource = new BindingList<PurchaseViewModel>();
            
            this.shouldEnterUserInfoFlag = true;
            this.confirmOrderButton.Text = "Enter Client";
            this.TotalOrderPriceTextBox.Text = "Client info: ";
            this.TotalOrderPriceTextBox.Enabled = true;            
        }
    }
    private void EnterPurchaseButtonClick(object sender, EventArgs e)
    {
        var quantity = double.Parse(this.quantityTextBox.Text.Replace("Quantity:", string.Empty).Trim());
        var purchasePrice = quantity * this.currentSelectedMaterial.PricePerKilogram;

        ((BindingList<PurchaseViewModel>)this.purchasesDataGridView.DataSource).Add(new PurchaseViewModel()
        {
            Height = double.Parse(this.heightTextBox.Text.Replace("Height:", string.Empty).Trim()),
            Width = double.Parse(this.widthTextBox.Text.Replace("Width:", string.Empty).Trim()),
            QuantityInKilograms = quantity,
            MaterialName = this.currentSelectedMaterial.Name,
            MaterialPrice = this.currentSelectedMaterial.PricePerKilogram ?? 0,
            Price = purchasePrice ?? 0
        });

        var totalValueString = this.TotalOrderPriceTextBox.Text.Replace("Total:", string.Empty).Trim();

        if (string.IsNullOrEmpty(totalValueString))
        {
            totalValueString = "0";
        }

        var total = double.Parse(totalValueString) + purchasePrice;
        this.TotalOrderPriceTextBox.Text = "Total: " + total.ToString();

        this.heightTextBox.Text = "Height: ";
        this.widthTextBox.Text = "Width: ";
        this.quantityTextBox.Text = "Quantity: ";
    }

    private void SetUpDataGridView<TViewModel>(DataGridView view, IEnumerable data, DataGridViewCRUDOption options = DataGridViewCRUDOption.None)
    {
        var dataSource = new BindingList<TViewModel>(data.To<TViewModel>().ToList());
        view.DataSource = dataSource;

        if (options.HasFlag(DataGridViewCRUDOption.Create))
        {
            dataSource.AllowNew = true;
        }

        if (options.HasFlag(DataGridViewCRUDOption.Delete))
        {
            dataSource.AllowRemove = true;
        }

        if (options.HasFlag(DataGridViewCRUDOption.Update))
        {
            dataSource.AllowEdit = true;
        }

        view.Columns["ID"].Visible = false;
    }
    private void AddColumnToDataGridView(DataGridView view, string headerText, string text)
    {
        var buttonColumn = new DataGridViewButtonColumn();
        buttonColumn.Text = text;
        buttonColumn.HeaderText = headerText;
        buttonColumn.Name = headerText;
        buttonColumn.UseColumnTextForButtonValue = true;


        if (!view.Columns.Contains(buttonColumn.HeaderText))
        {
            view.Columns.Add(buttonColumn);
        }
    }
}
