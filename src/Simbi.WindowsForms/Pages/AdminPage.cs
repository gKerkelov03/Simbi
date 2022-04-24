using Simbi.Common;
using Simbi.Mappings;
using Simbi.Services;
using Simbi.Services.Data.Contracts;
using Simbi.WindowsForms.Infrastructure;
using Simbi.WindowsForms.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class AdminPage : Form
{
    private UserManager userManager;
    private Redirector redirector;
    private readonly IMaterialsService materialsService;
    private readonly IPurchasesService purchasesService;
    private readonly IOrdersService ordersService;
    private readonly IAdminRemarksService adminRemarksService;

    public AdminPage(UserManager userManager, Redirector redirector, IMaterialsService materialsService, IPurchasesService purchasesService, IOrdersService ordersService, IAdminRemarksService adminRemarksService)
    {
        this.userManager = userManager;
        this.redirector = redirector;
        this.materialsService = materialsService;
        this.purchasesService = purchasesService;
        this.ordersService = ordersService;
        this.adminRemarksService = adminRemarksService;
        InitializeComponent();
    }

    private void LogoutButtonClick(object sender, EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }

    private async void AdminPage_Load(object sender, EventArgs e)
    {

        #region Orders
        var orders = (await this.ordersService.GetAll()).To<OrderWithoutPurchasesViewModel>();
        var ordersDataSource = new BindingList<OrderWithoutPurchasesViewModel>(orders.ToList());                

        this.ordersDataGridView.DataSource = ordersDataSource;

        ordersDataSource.AllowRemove = true;

        var deleteButtonColumnOrders = new DataGridViewButtonColumn();
        deleteButtonColumnOrders.Text = "Delete";
        deleteButtonColumnOrders.HeaderText = "Delete";
        deleteButtonColumnOrders.UseColumnTextForButtonValue = true;

        var selectPurchasesButtonColumn = new DataGridViewButtonColumn();
        selectPurchasesButtonColumn.Text = "Select";
        selectPurchasesButtonColumn.HeaderText = "Purchases";
        selectPurchasesButtonColumn.UseColumnTextForButtonValue = true;        

        this.ordersDataGridView.Columns.Add(selectPurchasesButtonColumn);
        this.ordersDataGridView.Columns.Add(deleteButtonColumnOrders);
        this.ordersDataGridView.Columns["ID"].Visible = false;
        #endregion

        #region Materials
        var materials = (await this.materialsService.GetAll()).To<MaterialViewModel>();
        var materialsDataSource = new BindingList<MaterialViewModel>(materials.ToList());

        materialsDataSource.AllowNew = true;
        materialsDataSource.AllowRemove = true;
        materialsDataSource.AllowEdit = true;

        var deleteButtonColumnMaterials = new DataGridViewButtonColumn();
        deleteButtonColumnMaterials.Text = "Delete";
        deleteButtonColumnMaterials.HeaderText = "Delete";
        deleteButtonColumnMaterials.UseColumnTextForButtonValue = true;

        this.materialsDataGridView.DataSource = materialsDataSource;
        this.materialsDataGridView.Columns.Add(deleteButtonColumnMaterials);
        this.materialsDataGridView.Columns["ID"].Visible = false;
        #endregion

        #region AdminRemarks
        var temp = (await this.adminRemarksService.GetAll()).ToList();
        var remarks = temp.To<AdminRemarkViewModel>().ToList();
        var remarksDataSource = new BindingList<AdminRemarkViewModel>(remarks.ToList());
        
        remarksDataSource.AllowRemove = true;

        var deleteButtonColumnRemarks = new DataGridViewButtonColumn();
        deleteButtonColumnRemarks.Text = "Delete";
        deleteButtonColumnRemarks.HeaderText = "Delete";
        deleteButtonColumnRemarks.UseColumnTextForButtonValue = true;

        this.adminRemarksDataGridView.DataSource = remarksDataSource;
        this.adminRemarksDataGridView.Columns.Add(deleteButtonColumnRemarks);
        this.adminRemarksDataGridView.Columns["ID"].Visible = false;
        #endregion
    }

    private async void ordersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var senderGrid = (DataGridView)sender;

        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
        {
            var id = new Guid(senderGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            var purchases = (await this.ordersService.GetById(id)).Purchases.To<PurchaseViewModel>();
            var purchasesModel = new BindingList<PurchaseViewModel>(purchases.ToList());           

            this.purchasesDataGridView.DataSource = purchasesModel;
        }
    }
}
