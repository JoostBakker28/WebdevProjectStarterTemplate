using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Tls;
using System.Diagnostics.Eventing.Reader;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class TafelSelectieModel : PageModel { 
        
       public IEnumerable<Tafel> Tafels { get { return new TafelRepository().Get(); } }//Haal alle tafels op


}

}
