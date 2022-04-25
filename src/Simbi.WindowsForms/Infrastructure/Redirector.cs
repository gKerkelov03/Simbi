using System.Windows.Forms;
using Simbi.Common;
using Simbi.Data;
using Simbi.Data.Repositories;
using Simbi.Services;
using Simbi.Services.Data;
using Simbi.Services.Data.Contracts;
using Simbi.Services.Data.Simbi.Services.Data;

namespace Simbi.WindowsForms.Infrastructure;

public class Redirector
{
    private readonly UserManager userManager;
    private readonly IPurchasesService purchasesService;
    private readonly IOrdersService ordersService;
    private readonly IAdminRemarksService adminRemarksService;
    private readonly IMaterialsService materialsService;

    public Redirector(UserManager userManager, IPurchasesService purchasesService, IOrdersService ordersService, IAdminRemarksService adminRemarksService, IMaterialsService materialsService)
    {
        this.userManager = userManager;
        this.purchasesService = purchasesService;
        this.ordersService = ordersService;
        this.adminRemarksService = adminRemarksService;
        this.materialsService = materialsService;
    }

    public void RedirectTo(PageName page, object currentPage)
    {
        Form newPage = null;

        if (page == PageName.Home)
        {
            newPage = new HomePage(this.userManager, this);
        }
        else if (page == PageName.Cashier)
        {
            newPage = new CashierPage(userManager, this, materialsService, ordersService, adminRemarksService);
        }
        else if (page == PageName.Admin)
        {
            newPage = new AdminPage(userManager, this, materialsService, ordersService, adminRemarksService);
        }

        newPage.Show();

        if (currentPage is CredentialsForm)
        {
            (currentPage as CredentialsForm).Parent.Hide();
        }

        (currentPage as Form).Close();
    }
}
