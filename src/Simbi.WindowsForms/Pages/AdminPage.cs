using Simbi.Common;
using Simbi.Services;
using Simbi.Services.Data;
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

    private void button1_Click(object sender, System.EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }    

    private async void AdminPage_Load(object sender, System.EventArgs e)
    {
        this.materialsDataGridView.DataSource = await this.materialsService.GetAll();
        this.ordersDataGridView.DataSource = await this.ordersService.GetAll();
        this.adminRemarksDataGridView.DataSource = (await this.adminRemarksService.GetAll(adminRemark => adminRemark.Creator.Username == userManager.CurrentUserUsername()));
    }

    private void label1_Click(object sender, System.EventArgs e)
    {

    }

    private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
    {

    }
}
