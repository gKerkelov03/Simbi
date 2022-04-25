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

public partial class AdminPage : Form
{
    private UserManager userManager;
    private Redirector redirector;
    private readonly IMaterialsService materialsService;
    private readonly IOrdersService ordersService;
    private readonly IAdminRemarksService adminRemarksService;

    public AdminPage(UserManager userManager, Redirector redirector, IMaterialsService materialsService, IOrdersService ordersService, IAdminRemarksService adminRemarksService)
    {
        this.userManager = userManager;
        this.redirector = redirector;
        this.materialsService = materialsService;
        this.ordersService = ordersService;
        this.adminRemarksService = adminRemarksService;
        InitializeComponent();
    }

    private async void AdminPage_Load(object sender, EventArgs e)
    {
        SetUpDataGridView<OrderViewModel>(ordersDataGridView, await this.ordersService.GetAll(), DataGridViewCRUDOption.Delete);
        AddColumnToDataGridView(ordersDataGridView, "Purchases", "Select");
        AddColumnToDataGridView(ordersDataGridView, "Delete", "Delete");        
        
        SetUpDataGridView<MaterialViewModel>(materialsDataGridView, await this.materialsService.GetAll(material => !material.IsDeleted), DataGridViewCRUDOption.Delete | DataGridViewCRUDOption.Create | DataGridViewCRUDOption.Update);
        AddColumnToDataGridView(materialsDataGridView, "Delete", "Delete");
        materialsDataGridView.UserAddedRow += MaterialsDataGridViewAddHandler;
        materialsDataGridView.CellEndEdit += MaterialsDataGridViewEditHandler;

        SetUpDataGridView<AdminRemarkViewModel>(adminRemarksDataGridView, await this.adminRemarksService.GetAll(), DataGridViewCRUDOption.Delete);
        AddColumnToDataGridView(adminRemarksDataGridView, "Delete", "Delete");
    }

    private void MaterialsDataGridViewAddHandler(object sender, DataGridViewRowEventArgs e) => this.materialsService.Add(((DataGridView)sender).Rows[e.Row.Index - 1].DataBoundItem.To<MaterialServiceModel>());

    private void MaterialsDataGridViewEditHandler(object sender, DataGridViewCellEventArgs e) => this.materialsService.Update(((DataGridView)sender).Rows[e.RowIndex].DataBoundItem.To<MaterialServiceModel>());

    private async void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var senderGrid = (DataGridView)sender;

        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn buttonColumn && e.RowIndex >= 0)
        {
            var id = new Guid(senderGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            if (buttonColumn.Text == "Select")
            {
                var order = await this.ordersService.GetById(id);
                SetUpDataGridView<PurchaseViewModel>(purchasesDataGridView, order.Purchases);
                this.purchsesTitle.Text = $"Purchases in the selected order ({order.ClientName})";
            }
            else if (buttonColumn.Text == "Delete")
            {
                if(senderGrid == this.ordersDataGridView)
                {
                    if (this.purchsesTitle.Text.Contains(senderGrid.Rows[e.RowIndex].DataBoundItem.To<OrderViewModel>().ClientName))
                    {
                        this.purchsesTitle.Text = "Purchases in the selected order";
                        this.purchasesDataGridView.DataSource = null;
                    }

                    await this.ordersService.DeleteById(id);
                }
                else if(senderGrid == this.materialsDataGridView)
                {
                    var entity = await this.materialsService.GetById(id);
                    entity.IsDeleted = true;
                    await this.materialsService.Update(entity);
                }
                else if(senderGrid == this.adminRemarksDataGridView)
                {
                    await this.adminRemarksService.DeleteById(id);
                }

                senderGrid.Rows.RemoveAt(e.RowIndex);
            }
        }
    }

    private void SignOutButtonClick(object sender, EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }

    private void RegisterButtonClick(object sender, EventArgs e)
    {
        new RegisterForm(this, userManager).Show();
        this.Enabled = false;
    }

    private void RefreshButtonClick(object sender, EventArgs e) => AdminPage_Load(null, null);

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
