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
    private static readonly UserManager userManager = new UserManager();
    private static readonly IPurchasesService purchasesService = new PurchasesService(new PurchasesRepository(new ApplicationDbContext()));
    private static readonly IOrdersService ordersService = new OrdersService(new OrdersRepository(new ApplicationDbContext()));
    private static readonly IAdminRemarksService adminRemarksService = new AdminRemarksService(new AdminRemarksRepository(new ApplicationDbContext()));
    private static readonly IMaterialsService materialsService = new MaterialsService(new MaterialsRepository(new ApplicationDbContext()));

    public void RedirectTo(PageName page, object currentPage)
    {
        Form newPage = null;

        if (page == PageName.Home)
        {
            newPage = new HomePage();
        }
        else if (page == PageName.Cashier)
        {
            newPage = new CashierPage(userManager, this, materialsService, purchasesService, ordersService, adminRemarksService);
        }
        else if (page == PageName.Admin)
        {
            newPage = new AdminPage(userManager, this, materialsService, purchasesService, ordersService, adminRemarksService);
        }

        newPage.Show();

        if (currentPage is CredentialsForm)
        {
            (currentPage as CredentialsForm).Parent.Hide();
        }

        (currentPage as Form).Close();
    }
}
