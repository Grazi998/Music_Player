#pragma checksum "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\Admin\Songs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "402eb69ec10bdb7964e42c7fd24d549a2b10282c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Songs), @"mvc.1.0.view", @"/Views/Admin/Songs.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"402eb69ec10bdb7964e42c7fd24d549a2b10282c", @"/Views/Admin/Songs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fefed1c5aca093887050f5e359d92112b5622638", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Songs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\Admin\Songs.cshtml"
  
    ViewData["Title"] = "allSongs";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>SONGS</h1>
<div>
    <table id=""artist_table"">
        <thead>
            <tr>
                <td>ID</td>
                <td>NAME</td>
                <td>LENGTH</td>
                <td>ARTIST</td>
            </tr>
        </thead>
        <tbody id=""tb"">
        </tbody>
    </table>
    <br />
    <button id=""add"">Add new</button>


</div>

<script type=""text/javascript"">

    document.getElementById(""add"").addEventListener(""click"", Add)
    var artists = [];
    Get();
    async function Get() {
        await axios.get('/api/artist').then(response => GetArtists(response.data));
        axios.get('/api/song').then(response => Show(response.data));
    }
    
    function Add() {
        parent.location = ""/music/newSong"";
    }
    function GetArtists(data) {
        for (var i = 0; i < data.length; i++) {
            artists.push(data[i]);
        }
        console.log(artists);
    }

    //PRIKAZ 
    function Show(data) {
        let tb = document.getEl");
            WriteLiteral(@"ementById(""tb"");
        console.log(data);
        for (var i = 0; i < data.length; i++) {
            var btnR = document.createElement(""button"");
            var btnE = document.createElement(""button"");
            var row = document.createElement(""tr"");

            var rowid = document.createElement(""td"");
            rowid.innerHTML = `${data[i].id}`;
            var rowname = document.createElement(""td"");
            rowname.innerHTML = `${data[i].name}`;
            var rowlength = document.createElement(""td"");
            rowlength.innerHTML = `${data[i].length}`;

            var rowartist = document.createElement(""td"");
            for (var j = 0; j < artists.length; j++) {
                if (data[i].artistID == artists[j].id) {
                    rowartist.innerHTML = `${artists[j].name}`;
                    break;
                }
                else {
                    rowartist.innerHTML = ""Unknown"";
                }
         
            }
           
        ");
            WriteLiteral(@"    row.appendChild(rowid);
            row.appendChild(rowname);
            row.appendChild(rowlength);
            row.appendChild(rowartist);

            btnR.innerHTML = ""Remove"";
            btnR.id = `${data[i].id}`;
            btnR.addEventListener(""click"", DeleteSong);

            btnE.innerHTML = ""Edit"";
            btnE.id = `${data[i].id}`;
            btnE.addEventListener(""click"", Edit);
            var td = document.createElement(""td"");
            td.appendChild(btnE);
            td.appendChild(btnR);
            row.appendChild(td);
            tb.appendChild(row);
        }
        function Edit() {
            var id = event.target.id;
            sessionStorage.setItem(""EditSongId"", `${id}`);
            window.location = ""/music/editSong"";
        }

        function DeleteSong() {
            var id = event.target.id;
            console.log(""ids"");
            $.ajax({ url: `/api/song/delete/${id}`, method: ""DELETE"" }).then(response => {
                w");
            WriteLiteral("indow.location.reload();\r\n                \r\n            });\r\n            \r\n        }\r\n    }\r\n    \r\n</script>\r\n");
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
