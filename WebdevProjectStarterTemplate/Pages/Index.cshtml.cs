using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.Common;

namespace WebdevProjectStarterTemplate.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


}