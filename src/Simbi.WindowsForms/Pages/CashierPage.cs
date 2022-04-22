using Simbi.Common;
using Simbi.Data.Models;
using Simbi.Services;
using Simbi.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class CashierPage : Form
{
    private readonly UserManager userManager;
    private readonly Redirector redirector;
    private readonly IMaterialsService materialsService;
    private readonly IPurchasesService purchasesService;
    private readonly IOrdersService ordersService;
    private readonly IAdminRemarksService adminRemarksService;

    private Order currentOrder;

    public CashierPage(UserManager UserManager, Redirector redirector, IMaterialsService materialsService, IPurchasesService purchasesService, IOrdersService ordersService, IAdminRemarksService adminRemarksService)
    {
        this.userManager = UserManager;
        this.redirector = redirector;
        this.materialsService = materialsService;
        this.purchasesService = purchasesService;
        this.ordersService = ordersService;
        this.adminRemarksService = adminRemarksService;

        this.currentOrder = new Order();
        this.currentOrder.Purchases = new List<Purchase>();

        InitializeComponent();
    }

    private void LogoutButtonClick(object sender, EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }       

    private async void CashierPage_Load(object sender, EventArgs e)
    {
        this.titleLabel.Text = "Keep up the good work " + this.userManager.CurrentUserUsername();

        this.materialsDataGridView.DataSource = await this.materialsService.GetAll();
        this.currentOrderDataGridView.DataSource = currentOrder.Purchases;
        this.adminRemarksDataGridView.DataSource = (await this.adminRemarksService.GetAll(adminRemark => adminRemark.Creator.Username == userManager.CurrentUserUsername()));

    }
}
