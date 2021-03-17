dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
dotnet nuget add source http://325e8035z0.qicp.vip:1212/ -n nuget.luesheng

dotnet pack -c Release /p:version=$BUILD_NUMBER

dotnet nuget push $PROJECT_DIR/bin/Release/Ls.Sass.Storage.1.0.0.$BUILD_NUMBER.nupkg -k luesheng.nuget -s http://325e8035z0.qicp.vip:1212/