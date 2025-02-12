using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCIA
{
    public partial class SolrInstaller : Form
    {
        string destFolder = string.Empty;
        DBServerDetails dbServer;
        List<VersionPrerequisites> prereqs;
        const string zipType = "sitecoredevsetup";
        string version = "10.0";
        bool xpoFile = true;
        ZipVersions zipVersions = null;
        public SolrInstaller()
        {
            InitializeComponent();

            switch (Version.SitecoreVersion)
            {
                case "10.0":
                case "9.3":
                    destFolder = CommonFunctions.GetZipNamefromWdpVersion("sitecoredevsetup", Version.SitecoreVersion);
                    zipVersions = CommonFunctions.GetZipVersionData(Version.SitecoreVersion, "sitecoredevsetup");
                    prereqs = CommonFunctions.GetVersionPrerequisites(Version.SitecoreVersion, "sitecoredevsetup");
                    xpoFile = false;
                    break;
                case "9.1":
                    destFolder = CommonFunctions.GetZipNamefromWdpVersion("sitecoresif", Version.SitecoreVersion);
                    zipVersions = CommonFunctions.GetZipVersionData(Version.SitecoreVersion, "sitecoresif");
                    prereqs = CommonFunctions.GetVersionPrerequisites(Version.SitecoreVersion, "sitecoresif");
                    break;
                default:
                    break;
            }

            ChangeValues();
        }

        private void SetStatusMessage(string statusmsg, Color color)
        {
            lblStatus.ForeColor = color;
            lblStatus.Text = statusmsg;
        }

        void WriteFile(string path)
        {
            string solrRoot = txtSolrRoot.Text + @"\" + txtSolrPrefix.Text + txtSolrVersion.Text;
            using var file = new StreamWriter(path);

            file.WriteLine("{");
            file.WriteLine("    \"Parameters\": {");
            file.WriteLine("        \"SolrVersion\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"The version of Solr to install\",");
            file.WriteLine("            \"DefaultValue\": \"" + txtSolrVersion.Text + "\",");
            file.WriteLine("            \"Validate\": \"[variable('Test.Solr.Download.Availability')]\"");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrDomain\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\" : \"The url/domain for Solr, used to create Self-Signed SSL Certificate\",");
            file.WriteLine("            \"DefaultValue\" : \"" + txtSolrDomain.Text + "\"");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrPort\": {");
            file.WriteLine("            \"Type\": \"Int\",");
            file.WriteLine("            \"Description\": \"The Solr port.\",");
            file.WriteLine("            \"DefaultValue\": " + txtSolrPort.Text + "");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrServicePrefix\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"The Solr service prefix name.\",");
            file.WriteLine("            \"DefaultValue\": \"" + txtSolrPrefix.Text + "\"");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrInstallRoot\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"The file path to install Solr. This config will add the prefix and solr version e.g C:\\\\Solr becomes C:\\\\Solr\\\\[SolrServicePrefix]Solr-8.4.0\",");
            file.WriteLine("            \"DefaultValue\": \"C:\\\\Solr\"");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrSourceURL\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\" : \"Solr download archive location\",");
            file.WriteLine("            \"DefaultValue\" : \"" + txtSolrSrc.Text + "\"");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrCloud\": {");
            file.WriteLine("            \"Type\": \"Switch\",");
            file.WriteLine("            \"Description\": \"Start Solr as the SolrCloud development version.\",");
            file.WriteLine("            \"DefaultValue\": false");
            file.WriteLine("        },");
            file.WriteLine("        \"JavaDownloadURL\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"Download location of AdoptOpenJDK\",");
            file.WriteLine("            \"DefaultValue\": \"" + txtJavaDownloadUrl.Text + "\"");
            file.WriteLine("        },");
            file.WriteLine("        \"ApacheCommonsDaemonURL\" : {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"Download Location of Apache Commons Daemon\",");
            file.WriteLine("            \"DefaultValue\": \"http://archive.apache.org/dist/commons/daemon/binaries/windows/commons-daemon-1.1.0-bin-windows.zip\"");
            file.WriteLine("        },");
            file.WriteLine("        \"TempLocation\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"Alternative location to save downloads. If left on the default $Env:Temp will be used.\",");
            file.WriteLine("            \"DefaultValue\": \"SIF-Default\",");
            file.WriteLine("            \"Validate\": \"[TestPath(variable('Temp.Location'))]\"");
            file.WriteLine("        },");
            file.WriteLine("        \"ServiceLocation\": {");
            file.WriteLine("            \"Type\": \"String\",");
            file.WriteLine("            \"Description\": \"Registry location of Windows Services.\",");
            file.WriteLine("            \"DefaultValue\": \"HKLM:SYSTEM\\\\CurrentControlSet\\\\Services\"");
            file.WriteLine("        },");
            file.WriteLine("        \"SolrServiceStartTimeout\": {");
            file.WriteLine("            \"Type\": \"Int\",");
            file.WriteLine("            \"Description\": \"Solr service start timeout.\",");
            file.WriteLine("            \"DefaultValue\": 8000");
            file.WriteLine("        }");
            file.WriteLine("    },");
            file.WriteLine("    \"Variables\": {");
            file.WriteLine("        \"Solr.Download.URL\": \"[join(Values:variable('Solr.Path'),Delimiter:'/')]\",");
            file.WriteLine("        \"Solr.Path\": [");
            file.WriteLine("            \"[parameter('SolrSourceURL')]\",");
            file.WriteLine("            \"[parameter('SolrVersion')]\",");
            if (txtSolrVersion.Text.Substring(0, 1) == "9")
            {
                file.WriteLine("            \"[concat(variable('Solr.FileName'),'.tgz')]\"");
            }
            else
            {
                file.WriteLine("            \"[concat(variable('Solr.FileName'),'.zip')]\"");
            }
            file.WriteLine("        ],");
            file.WriteLine("        \"Solr.FileName\": \"[concat('solr-',parameter('SolrVersion'))]\",");
            file.WriteLine("        \"Solr.tar\": \"solr.tar\",");
            file.WriteLine("        \"Solr.Service\": \"[concat(parameter('SolrServicePrefix'),variable('Solr.FileName'))]\",");
            file.WriteLine("        \"Solr.Uri\": \"[concat('https://',parameter('SolrDomain'),':',parameter('SolrPort'))]\",");
            file.WriteLine("        \"Solr.Install.Path\": \"[JoinPath(parameter('SolrInstallRoot'),variable('Solr.Service'))]\",");
            file.WriteLine("        \"Java.Install.Path\": \"[GetItem(Path:JoinPath(variable('Solr.Install.Path'),'jdk*'))]\",");
            file.WriteLine("        \"ACD.Install.Path\": \"[JoinPath(variable('Solr.Install.Path'),'daemon')]\",");
            file.WriteLine("        \"Temp.Location\" : \"[if(variable('Test.Temp.Location'),Environment('Temp'),parameter('TempLocation'))]\",");
            file.WriteLine("        \"Test.Temp.Location\" : \"[equal(parameter('TempLocation'),'SIF-Default')]\",");
            file.WriteLine("        \"Check.Solr.Path\": \"[if(variable('Test.Solr.Path'),'*** Solr install path is not available. ***','Solr install path is available.')]\",");
            file.WriteLine("        \"Check.Solr.Service\": \"[if(variable('Test.Solr.Service'),'*** Solr service already exists. ***','Solr service name is available.')]\",");
            file.WriteLine("        \"Check.Solr.Port\": \"[if(variable('Test.Solr.Port'),'*** Solr port is in use. ***','Solr port is available.')]\",");
            file.WriteLine("        \"Test.Solr\": \"[or(variable('Test.Solr.Path'),variable('Test.Solr.Service'),variable('Test.Solr.Port'))]\",");
            file.WriteLine("        \"Test.Solr.Path\": \"[TestPath(variable('Solr.Install.Path'))]\",");
            file.WriteLine("        \"Test.Solr.Service\": \"[TestPath(JoinPath(parameter('ServiceLocation'),variable('Solr.Service')))]\",");
            file.WriteLine("        \"Test.Solr.Port\": \"[SelectObject(InputObject:variable('Ping.Solr.Port'),ExpandProperty:'TCPTestSucceeded')]\",");
            file.WriteLine("        \"Ping.Solr.Port\": \"[TestNetConnection(Port:parameter('SolrPort'),Computer:'Localhost',WarningAction:'SilentlyContinue')]\",");
            file.WriteLine("        \"Test.Solr.Download.Availability\": \"[Equal(variable('Solr.Download.StatusCode'),200)]\",");
            file.WriteLine("        \"Solr.Download.StatusCode\": \"[SelectObject(InputObject:variable('Get.Solr.Download.Availability'),ExpandProperty:'StatusCode')]\",");
            file.WriteLine("        \"Get.Solr.Download.Availability\":\"[InvokeWebRequest(URI:variable('Solr.Download.URL'),Method:'head',UseBasicParsing:true)]\",");
            file.WriteLine("        \"Solr.StartupType\": \"[if(parameter('SolrCloud'),'solrcloud','')]\",");
            file.WriteLine("        \"Java.Download.Temp\": \"[JoinPath(variable('Temp.Location'),'java.zip')]\",");
            file.WriteLine("        \"ACD.Download.Temp\": \"[JoinPath(variable('Temp.Location'),'ACD.zip')]\",");
            if (txtSolrVersion.Text.Substring(0, 1) == "9")
            {
                file.WriteLine("        \"Solr.Download.Temp\" : \"[JoinPath(variable('Temp.Location'),'solr.tgz')]\",");
            }
            else
            {
                file.WriteLine("        \"Solr.Download.Temp\" : \"[JoinPath(variable('Temp.Location'),'solr.zip')]\",");
            }
            
            file.WriteLine("        \"KeyStoreFilePath\": \"[JoinPath(variable('Solr.Install.Path'),'server','etc')]\",");
            file.WriteLine("        \"KeyStoreFile\": \"solr-ssl.keystore\",");
            file.WriteLine("        \"Secure.Solr.Key.Password\": \"[ConvertToSecureString(String:variable('Plaintext.Solr.Key.Password'),AsPlainText:True,Force:True)]\",");
            file.WriteLine("        \"Plaintext.Solr.Key.Password\": \"[RandomString(Length:20,DisAllowSpecial:True)]\",");
            file.WriteLine("        \"Solr.JKS.Keystore.Path\": \"[concat(variable('Solr.Install.Path'),'\\\\server\\\\etc\\\\solr-ssl.keystore.jks')]\",");
            file.WriteLine("        \"Solr.P12.Keystore.Path\": \"[concat(variable('Solr.Install.Path'),'\\\\server\\\\etc\\\\solr-ssl.keystore.p12')]\",");
            file.WriteLine("        \"Java.KeyTool.Location\": \"[JoinPath(variable('Java.Install.Path'),'bin','keytool.exe')]\",");
            file.WriteLine("        \"ACD.Binary.Location\": \"[JoinPath(variable('ACD.Install.Path'),'amd64','prunsrv.exe')]\",");
            file.WriteLine("        \"Solr.Bin.Location\": \"[JoinPath(variable('Solr.Install.Path'),'bin')]\",");
            file.WriteLine("        \"Solr.CMD.Location\" : \"[JoinPath(variable('Solr.Bin.Location'),'Solr.cmd')]\",");
            file.WriteLine("        \"Solr.In.CMD.Location\" : \"[JoinPath(variable('Solr.Bin.Location'),'Solr.in.cmd')]\"");
            file.WriteLine("    },");
            file.WriteLine("    \"Register\":{");
            file.WriteLine("        \"Tasks\":{");
            file.WriteLine("            \"StartProcess\" : \"Start-Process\",");
            if (txtSolrVersion.Text.Substring(0, 1) == "9")
            {
                file.WriteLine("            \"Expand7Zip\" : \"Expand-7Zip\",");
            }
            file.WriteLine("            \"ExpandArchive\" : \"Expand-Archive\",");
            file.WriteLine("            \"AddContent\" : \"Add-Content\",");
            file.WriteLine("            \"RemoveItem\": \"Remove-Item\",");
            file.WriteLine("            \"MoveItem\": \"Move-Item\",");
            file.WriteLine("            \"WriteInformation\": \"Write-Information\",");
            file.WriteLine("            \"WriteError\": \"Write-Error\"");
            file.WriteLine("        },");
            file.WriteLine("        \"ConfigFunction\":{");
            file.WriteLine("            \"SelectObject\": \"Select-Object\",");
            file.WriteLine("            \"InvokeWebRequest\": \"Invoke-WebRequest\",");
            file.WriteLine("            \"ConvertToSecureString\": \"ConvertTo-SecureString\",");
            file.WriteLine("            \"TestPath\": \"Test-Path\",");
            file.WriteLine("            \"GetItem\": \"Get-Item\",");
            file.WriteLine("            \"TestNetConnection\": \"Test-NetConnection\"");
            file.WriteLine("        }");
            file.WriteLine("    },");
            file.WriteLine("    \"Tasks\": {");
            file.WriteLine("        \"TestSolrPath\":{");
            file.WriteLine("            \"Description\": \"Detects if Solr path has already been used.\",");
            file.WriteLine("            \"Type\": \"WriteInformation\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"MessageData\": \"[variable('Check.Solr.Path')]\",");
            file.WriteLine("                \"InformationAction\": \"Continue\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"TestSolrService\":{");
            file.WriteLine("            \"Description\": \"Detects if Solr service name has already been used.\",");
            file.WriteLine("            \"Type\": \"WriteInformation\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"MessageData\": \"[variable('Check.Solr.Service')]\",");
            file.WriteLine("                \"InformationAction\": \"Continue\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"TestSolrPort\":{");
            file.WriteLine("            \"Description\": \"Detects if the Solr port is in use.\",");
            file.WriteLine("            \"Type\": \"WriteInformation\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"MessageData\": \"[variable('Check.Solr.Port')]\",");
            file.WriteLine("                \"InformationAction\": \"Continue\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"ThrowIfTestsFail\":{");
            file.WriteLine("            \"Description\": \"Errors out if any of the tests fail.\",");
            file.WriteLine("            \"Type\": \"WriteError\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Exception\": \"Solr cannot be installed. Check the logs for the reason.\"");
            file.WriteLine("            },");
            file.WriteLine("            \"Skip\": \"[not(variable('Test.Solr'))]\"");
            file.WriteLine("        },");
            file.WriteLine("        \"CreateSolrFolder\":{");
            file.WriteLine("            \"Description\": \"Ensures the Solr install folder is available.\",");
            file.WriteLine("            \"Type\": \"EnsurePath\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Exists\": \"[variable('Solr.Install.Path')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"DownloadSolr\" :{");
            file.WriteLine("            \"Description\": \"Downloads Solr.\",");
            file.WriteLine("            \"Type\": \"DownloadFile\",");
            file.WriteLine("            \"Params\" :{");
            file.WriteLine("                \"SourceUri\" : \"[variable('Solr.Download.URL')]\",");
            file.WriteLine("                \"DestinationPath\" : \"[variable('Solr.Download.Temp')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            if (txtSolrVersion.Text.Substring(0, 1) == "9")
            {
                file.WriteLine("        \"UnpackSolr\" : {");
                file.WriteLine("            \"Description\": \"Unpacks Solr.\",");
                file.WriteLine("            \"Type\": \"Expand7Zip\",");
                file.WriteLine("            \"Params\" : {");
                file.WriteLine("                \"ArchiveFileName\" : \"[variable('Solr.Download.Temp')]\",");
                file.WriteLine("                \"TargetPath\" : \"[variable('Temp.Location')]\"");
                file.WriteLine("            }");
                file.WriteLine("        },");
            }
            else
            {
                file.WriteLine("        \"UnpackSolr\" : {");
                file.WriteLine("            \"Description\": \"Unpacks Solr.\",");
                file.WriteLine("            \"Type\": \"ExpandArchive\",");
                file.WriteLine("            \"Params\" : {");
                file.WriteLine("                \"Path\" : \"[variable('Solr.Download.Temp')]\",");
                file.WriteLine("                \"DestinationPath\" : \"[variable('Temp.Location')]\",");
                file.WriteLine("                \"Force\": true");
                file.WriteLine("            }");
                file.WriteLine("        },");
            }
            if (txtSolrVersion.Text.Substring(0, 1) == "9")
            {
                file.WriteLine("        \"UnpackSolrTar\" : {");
                file.WriteLine("            \"Description\": \"Unpacks Solr Tar.\",");
                file.WriteLine("            \"Type\": \"Expand7Zip\",");
                file.WriteLine("            \"Params\" : {");
                file.WriteLine("                \"ArchiveFileName\" : \"[JoinPath(variable('Temp.Location'),variable('Solr.Tar'))]\",");
                file.WriteLine("                \"TargetPath\" : \"[variable('Temp.Location')]\"");
                file.WriteLine("            }");
                file.WriteLine("        },");
            }
            file.WriteLine("        \"MoveSolr\": {");
            file.WriteLine("            \"Description\": \"Move Solr to working folder.\",");
            file.WriteLine("            \"Type\": \"MoveItem\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Path\": \"[JoinPath(variable('Temp.Location'),variable('Solr.Filename'),'*')]\",");
            file.WriteLine("                \"Destination\": \"[variable('Solr.Install.Path')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"DownloadJavaX64\": {");
            file.WriteLine("            \"Description\": \"Downloads Java x64.\",");
            file.WriteLine("            \"Type\": \"DownloadFile\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"SourceUri\" : \"[parameter('JavaDownloadURL')]\",");
            file.WriteLine("                \"DestinationPath\" : \"[variable('Java.Download.Temp')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"InstallJavaX64\": {");
            file.WriteLine("            \"Description\": \"Installs Java x64.\",");
            file.WriteLine("            \"Type\": \"ExpandArchive\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Path\": \"[variable('Java.Download.Temp')]\",");
            file.WriteLine("                \"DestinationPath\": \"[variable('Solr.Install.Path')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"CreateSolrSSL\": {");
            file.WriteLine("            \"Description\": \"Creates a website certificate for the Solr website.\",");
            file.WriteLine("            \"Type\": \"StartProcess\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"FilePath\": \"[variable('Java.KeyTool.Location')]\",");
            file.WriteLine("                \"ArgumentList\": \"[concat('-genkeypair -alias solr-ssl -keyalg RSA -keysize 2048 -keypass secret -storepass secret -validity 9999 -keystore ',variable('Solr.JKS.Keystore.Path'),' -ext SAN=',concat('DNS:',parameter('solrdomain'),',DNS:localhost',',IP:127.0.0.1'),' -dname \\\"CN=solrcert, OU=Created by https://www.sitecore.com\\\"')]\",");
            file.WriteLine("                \"Wait\": true");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"GenerateP12\": {");
            file.WriteLine("            \"Description\": \"Generate P12 certificate.\",");
            file.WriteLine("            \"Type\": \"StartProcess\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"FilePath\": \"[variable('Java.KeyTool.Location')]\",");
            file.WriteLine("                \"ArgumentList\": \"[concat('-importkeystore -srckeystore ',variable('Solr.JKS.Keystore.Path'),' -destkeystore ',variable('Solr.P12.Keystore.Path'),' -srcstoretype jks -deststoretype pkcs12 -deststorepass secret -srcstorepass secret')]\",");
            file.WriteLine("                \"Wait\": true");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"ImportSolrSSL\" :{");
            file.WriteLine("            \"Description\": \"Import Certificate to store.\",");
            file.WriteLine("            \"Type\": \"StartProcess\",");
            file.WriteLine("            \"Params\" : {");
            file.WriteLine("                \"FilePath\": \"certutil.exe\",");
            file.WriteLine("                \"ArgumentList\":");
            file.WriteLine("                    \"[concat('-f -p secret -importpfx ',variable('Solr.P12.Keystore.Path'))]\",");
            file.WriteLine("                \"Wait\" : true");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"AddSOLRConfiguration\": {");
            file.WriteLine("            \"Description\": \"Adds the SSL keys and Java location to the configuration.\",");
            file.WriteLine("            \"Type\": \"AddContent\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Value\": [");
            file.WriteLine("                    \"[concat('set SOLR_MODE=',variable('Solr.StartupType'))]\",");
            file.WriteLine("                    \"[concat('set SOLR_JAVA_HOME=\\\"',variable('Java.Install.Path'),'\\\"')]\",");
            var compared = String.Compare("8.4.0", txtSolrVersion.Text);
            if (compared >=0)
                if (txtSolrVersion.Text.Trim().StartsWith("8.10"))
                    file.WriteLine("                    \"set SOLR_SSL_KEY_STORE=etc/solr-ssl.keystore.p12\",");
                else
                    file.WriteLine("                    \"set SOLR_SSL_KEY_STORE=etc/solr-ssl.keystore.jks\",");
            else
                file.WriteLine("                    \"set SOLR_SSL_KEY_STORE=etc/solr-ssl.keystore.jks\",");
            file.WriteLine("                    \"set SOLR_SSL_KEY_STORE_PASSWORD=secret\",");
            if (compared >= 0)
                if (txtSolrVersion.Text.Trim().StartsWith("8.10"))
                    file.WriteLine("                    \"set SOLR_SSL_TRUST_STORE=etc/solr-ssl.keystore.p12\",");
                else
                    file.WriteLine("                    \"set SOLR_SSL_TRUST_STORE=etc/solr-ssl.keystore.jks\",");
            else
                file.WriteLine("                    \"set SOLR_SSL_TRUST_STORE=etc/solr-ssl.keystore.jks\",");

            file.WriteLine("                    \"set SOLR_SSL_TRUST_STORE_PASSWORD=secret\",");
            file.WriteLine("                    \"[concat('set SOLR_HOST=\\\"',parameter('SolrDomain'),'\\\"')]\",");
            file.WriteLine("                    \"[concat('set SOLR_Port=',parameter('SolrPort'))]\"");
            file.WriteLine("                ],");
            file.WriteLine("                \"Path\": \"[variable('Solr.In.CMD.Location')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"CreateACDFolder\": {");
            file.WriteLine("            \"Type\": \"EnsurePath\",");
            file.WriteLine("            \"Description\": \"Create path to install Apache Commons Daemon.\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Exists\" : \"[variable('ACD.Install.Path')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"DownloadACD\": {");
            file.WriteLine("            \"Description\": \"Downloads Apache Commons Daemon.\",");
            file.WriteLine("            \"Type\": \"DownloadFile\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"SourceUri\" : \"[parameter('ApacheCommonsDaemonURL')]\",");
            file.WriteLine("                \"DestinationPath\" : \"[variable('ACD.Download.Temp')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"InstallACD\":{");
            file.WriteLine("            \"Description\": \"Unpacks Apache Commons Daemon\",");
            file.WriteLine("            \"Type\": \"ExpandArchive\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Path\": \"[variable('ACD.Download.Temp')]\",");
            file.WriteLine("                \"DestinationPath\": \"[variable('ACD.Install.Path')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"CreateSOLRService\":{");
            file.WriteLine("            \"Description\": \"Creates Solr Service\",");
            file.WriteLine("            \"Type\": \"StartProcess\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"FilePath\": \"[variable('ACD.Binary.Location')]\",");
            file.WriteLine("                \"ArgumentList\": [");
            file.WriteLine("                    \"[concat('install ',variable('Solr.Service'))]\",");
            file.WriteLine("                    \"[concat('--DisplayName=\\\"',variable('Solr.Service'),'\\\"')]\",");
            file.WriteLine("                    \"--Startup=auto\",");
            file.WriteLine("                    \"--StartMode=exe\",");
            file.WriteLine("                    \"[concat('--StartImage=\\\"',variable('Solr.CMD.Location'),'\\\"')]\",");
            file.WriteLine("                    \"[concat('--StartPath=\\\"',variable('Solr.Bin.Location'),'\\\"')]\",");
            file.WriteLine("                    \"++StartParams=\\\"start\\\"\",");
            file.WriteLine("                    \"--StopMode=exe\",");
            file.WriteLine("                    \"[concat('--StopImage=\\\"',variable('Solr.CMD.Location'),'\\\"')]\",");
            file.WriteLine("                    \"[concat('--StopPath=\\\"',variable('Solr.Bin.Location'),'\\\"')]\",");
            file.WriteLine("                    \"++StopParams=\\\"stop\\\"\",");
            file.WriteLine("                    \"--StopTimeout=10\",");
            file.WriteLine("                    \"--StdOutput=auto\",");
            file.WriteLine("                    \"--StdError=auto\"");
            file.WriteLine("                ],");
            file.WriteLine("                \"Wait\": true");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"StartSolr\": {");
            file.WriteLine("            \"Description\": \"Runs the Solr service.\",");
            file.WriteLine("            \"Type\": \"ManageService\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Name\": \"[variable('Solr.Service')]\",");
            file.WriteLine("                \"Status\": \"Running\",");
            file.WriteLine("                \"PostDelay\": \"[parameter('SolrServiceStartTimeout')]\"");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"SetClusterScheme\": {");
            file.WriteLine("            \"Description\": \"Set cluster scheme in configuration so Zookeeper talks to Solr over HTTPS\",");
            file.WriteLine("            \"Type\": \"HttpRequest\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Uri\": \"[concat(variable('Solr.Uri'), '/solr/admin/collections?action=CLUSTERPROP&name=urlScheme&val=https&wt=json')]\",");
            file.WriteLine("                \"ContentType\": \"application/json\"");
            file.WriteLine("            },");
            file.WriteLine("            \"Skip\": \"[not(parameter('SolrCloud'))]\"");
            file.WriteLine("        }");
            file.WriteLine("    },");
            file.WriteLine("    \"UninstallTasks\": {");
            file.WriteLine("        \"StopSolrService\": {");
            file.WriteLine("            \"Description\" : \"Stops the Solr Service\",");
            file.WriteLine("            \"Type\": \"ManageService\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Name\": \"[variable('Solr.Service')]\",");
            file.WriteLine("                \"Status\": \"Stopped\",");
            file.WriteLine("                \"PostDelay\": 4000");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"RemoveSolrService\": {");
            file.WriteLine("            \"Description\": \"Removes the Solr Service.\",");
            file.WriteLine("            \"Type\": \"StartProcess\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"FilePath\": \"[variable('ACD.Binary.Location')]\",");
            file.WriteLine("                \"ArgumentList\": \"[concat('delete ',variable('Solr.Service'))]\",");
            file.WriteLine("                \"Wait\": true");
            file.WriteLine("            }");
            file.WriteLine("        },");
            file.WriteLine("        \"RemoveSolrFiles\": {");
            file.WriteLine("            \"Description\": \"Remove Solr folder and all files therein.\",");
            file.WriteLine("            \"Type\": \"RemoveItem\",");
            file.WriteLine("            \"Params\": {");
            file.WriteLine("                \"Path\": \"[variable('Solr.Install.Path')]\",");
            file.WriteLine("                \"Recurse\": true");
            file.WriteLine("            }");
            file.WriteLine("        }");
            file.WriteLine("    }");
            file.WriteLine("}");


            file.Dispose();
        }

        private bool CheckValidations()
        {
            if (string.IsNullOrWhiteSpace(txtSolrPort.Text)) { SetStatusMessage("Solr Port needed....", Color.Red); return false; }
            if (string.IsNullOrWhiteSpace(txtSolrRoot.Text)) { SetStatusMessage("Solr Root needed....", Color.Red); return false; }
            if (string.IsNullOrWhiteSpace(txtSolrVersion.Text)) { SetStatusMessage("Solr Version needed....", Color.Red); return false; }
            if (string.IsNullOrWhiteSpace(txtSolrDomain.Text)) { SetStatusMessage("Solr Domain needed....", Color.Red); return false; }
            if (string.IsNullOrWhiteSpace(txtJavaDownloadUrl.Text)) { SetStatusMessage("Java Download Url needed....", Color.Red); return false; }
            if (CommonFunctions.PortInUse(Convert.ToInt32(txtSolrPort.Text))) { SetStatusMessage("Solr Port in use....", Color.Red); return false; }

            return true;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (!CheckValidations()) return;
            string destPath = ".";
            //switch (Version.SitecoreVersion)
            //{
            //    case "10.0":
            //    case "9.3":
            //        destPath = ZipList.SitecoreDevSetupZip;
            //        break;
            //    case "9.1":
            //        destPath = ZipList.SitecoreSifZip;
            //        break;
            //    default:
            //        break;
            //}

            WriteFile(destPath + "\\" + SCIASettings.FilePrefixAppString + txtSolrPort.Text + " " + txtSolrVersion.Text + "-Solr-SingleDeveloper.json");
            CommonFunctions.LaunchPSScript("Install-SitecoreConfiguration -Path '" + destPath + @"\" + SCIASettings.FilePrefixAppString + txtSolrPort.Text + " " +  txtSolrVersion.Text + "-Solr-SingleDeveloper.json'");
        }

        private void lnkJavaDownloadUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkJavaDownloadUrl.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://adoptopenjdk.net/archive.html");
        }

        private void txtSolrPort_TextChanged(object sender, EventArgs e)
        {
            ChangeValues();
        }

        private void ChangeValues()
        {
            txtSolrUrl.Text = "https://localhost:" + txtSolrPort.Text + "/solr";
            txtSolrService.Text = txtSolrPrefix.Text + "solr-" + txtSolrVersion.Text;
        }

        private void txtSolrPrefix_TextChanged(object sender, EventArgs e)
        {
            ChangeValues();
        }

        private void txtSolrVersion_TextChanged(object sender, EventArgs e)
        {
            ChangeValues();
        }
    }
}
