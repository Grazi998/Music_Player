#pragma checksum "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\User\AllSongs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de11d049afb29f1c457e5f54a2401b779807a299"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_AllSongs), @"mvc.1.0.view", @"/Views/User/AllSongs.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de11d049afb29f1c457e5f54a2401b779807a299", @"/Views/User/AllSongs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fefed1c5aca093887050f5e359d92112b5622638", @"/Views/_ViewImports.cshtml")]
    public class Views_User_AllSongs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\User\AllSongs.cshtml"
  
    ViewData["Title"] = "AllSongs";
    ViewBag.Title = "AllSongs";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1><strong>All Songs</strong></h1>
<button id=""back"" onclick=""goBack()"">GO BACK</button>
<button id=""toPlaylists"">MY PLAYLISTS</button>
<table id=""songs_table"">
    <thead>
        <tr>
            <td>ID</td>
            <td>Name</td>
            <td>Length</td>
            <td>Artist</td>
            <td>Playlist</td>
        </tr>


    </thead>
    <tbody id=""tb"">
    </tbody>
</table>
<script type=""text/javascript"">

    var artists = [];
    var playlists = [];
    var user = """);
#nullable restore
#line 27 "C:\Users\5cepr\Desktop\Projekti_GK\Music_Player\Music_Player\Views\User\AllSongs.cshtml"
           Write(ViewBag.user);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
    Get();
    async function Get() {
        await axios.get('/api/artist').then(response => GetArtists(response.data));
        await axios.get(`/api/user/allplaylists/${user}`).then(response => GetPlaylists(response.data));
        await axios.get('/api/song').then(response => Show(response.data));
        document.getElementById(""toPlaylists"").addEventListener(""click"", function () {
            window.location = ""/music/user/playlists"";
        })
    }

    function goBack() {
        window.location = ""/"";
    }

    function GetPlaylists(data) {
        if (data != null) {
            for (var i = 0; i < data.length; i++) {
                playlists.push(data[i]);
            }
        }
        
    }

    function GetArtists(data) {
        for (var i = 0; i < data.length; i++) {
            artists.push(data[i]);
        }
    }

    async function Show(data) {
        let tb = document.getElementById(""tb"");
        for (var i = 0; i < data.length; i++) {
        ");
            WriteLiteral(@"    //var btn = document.createElement(""button"");
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

            var sel = document.createElement(""select"");
            sel.id = data[i].id;
            var opt = document.createElement(""option"");
            opt.text = ""ADD TO PLAYLIST.");
            WriteLiteral(@".."";
            opt.value = ""add"";
            sel.appendChild(opt);

            //var index;
            //await axios.get(`/api/playlist/getplaylistbysong/${data[i].id}`).then(resp => index = resp);

            //console.log(index);

            for (var j = 0; j < playlists.length; j++) {
                var option = document.createElement(""option"");
                option.textContent = playlists[j].title;
                option.id = playlists[j].id;
                
                //if (index.data.id == playlists[j].id) {
                //    console.log(""Mirko ljubav moja!"");
                //    option.selected = ""selected"";
                //}
                sel.appendChild(option);
            }
            sel.addEventListener(""change"", AddSongToPlaylist);
 



            row.appendChild(rowid);
            row.appendChild(rowname);
            row.appendChild(rowlength);
            row.appendChild(rowartist);

            
            

            //btn.inn");
            WriteLiteral(@"erHTML = ""Remove"";
            //btn.id = `${data[i].id}`;
            //btn.addEventListener(""click"", DeleteSong);

            var td = document.createElement(""td"");
            td.appendChild(sel);

            //td.appendChild(btn);
            row.appendChild(td);
            tb.appendChild(row);
        }
    }

    async function AddSongToPlaylist() {
        var song = event.target.id;
        var play;
        for (var i = 0; i < event.target.options.length; i++) {
            if (event.target.options[i].selected) {
                play = event.target.options[i].id;
                break;
            }
            else {
                play = ""nista"";
            }
        }
        event.target.selectedIndex = 0;
        await axios.post(""/api/playlist/addtoplaylist"", {
            ""id"": null,
            ""playlistid"": `${play}`,
            ""songid"": `${song}`
        });
        console.log(""Pjesma: "" + song + ""   Playlist: "" + play);
    }
</script>");
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
