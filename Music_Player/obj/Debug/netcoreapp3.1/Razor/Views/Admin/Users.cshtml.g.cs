#pragma checksum "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\Admin\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05a87485060d97089ca7ddedab481bc24c06e67f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Users), @"mvc.1.0.view", @"/Views/Admin/Users.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\_ViewImports.cshtml"
using Music_Player;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\_ViewImports.cshtml"
using Music_Player.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05a87485060d97089ca7ddedab481bc24c06e67f", @"/Views/Admin/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fefed1c5aca093887050f5e359d92112b5622638", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\Admin\Users.cshtml"
  
    ViewData["Title"] = "allUsers";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>USERS</h1>
<button id=""back"" onclick=""goBack()"">GO BACK</button>
<div>
    <table id=""artist_table"">
        <thead>
            <tr>
                <td>ID</td>
                <td>USERNAME</td>
            </tr>
        </thead>
        <tbody id=""tb"">
        </tbody>
    </table>


</div>

<script type=""text/javascript"">
    function goBack() {
        window.location = ""/music/adminhome"";
    }
    //PRIKAZ
    function Show(data) {

        let tb = document.getElementById(""tb"");

        for (var i = 0; i < data.length; i++) {
            var btn = document.createElement(""button"");
            var row = document.createElement(""tr"");

            var rowid = document.createElement(""td"");
            rowid.innerHTML = `${data[i].id}`;
            var rowusername = document.createElement(""td"");
            rowusername.innerHTML = `${data[i].username}`;


            row.appendChild(rowid);
            row.appendChild(rowusername);

            btn.innerHTML = ""Re");
            WriteLiteral(@"move"";
            btn.id = `${data[i].id}`;
            btn.addEventListener(""click"", DeleteUser);
            var td = document.createElement(""td"");
            td.appendChild(btn);
            row.appendChild(td);
            tb.appendChild(row);
        }
    }

    function DeleteUser() {
        var id = event.target.id;
        console.log(""Delete"");
        $.ajax({ url: `/api/user/delete/${id}`, method: ""DELETE"" }).then(response => {
            window.location.reload();
        });
    }
    axios.get('/api/user/allusers').then(response => Show(response.data));
</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
