using api;
using api.Buffer;
using TagsGenerator.Model;
using UploadTags;
using UploadTags.Interface;
using UploadTags.Models;
using UploadTags.Service;
using UploadTags.Service.Creazilla;
using UploadTags.Service.GetInforAndUpdateTags;
using Config = UploadTags.Models.Config;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Concurrent;
using System.Diagnostics;
using UploadTags.Service.MyApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Config>(a =>
{
    return new UploadTags.Models.Config()
    {
        Token = "",
        ConnectString = ""
    };
});
//builder.Services.AddHttpClient();
builder.Services.AddTransient<ITagsId, GetIdTagsFromCreazillaService>();
builder.Services.AddTransient<IWorker, Worker>();
builder.Services.AddLogging(a => a.AddConsole());
builder.Services.AddTransient<IUploadTagsService, UploadTagsService>();
builder.Services.AddTransient<ITagAdds, TagsAdds>();
builder.Services.AddSingleton<ConcurrentDictionary<string, int>>(a => new ConcurrentDictionary<string, int>());
builder.Services.AddTransient<IUpdateTags, UpdateTagsMyApi>();
builder.Services.AddHostedService<Startup>();
builder.Services.AddDbContext<TagsDbContext>((provider, builder) =>
{
    NpgsqlConnectionStringBuilder builderConnectStr = new NpgsqlConnectionStringBuilder();
    builderConnectStr.Password = "";
    builderConnectStr.Username = "";//builder.Configuration.GetSection("LoginDB").Value;
    builderConnectStr.Host = "";// builder.Configuration.GetSection("HostDB").Value;
    builderConnectStr.Port = 0;//int.Parse(builder.Configuration.GetSection("PortDB").Value);
    builderConnectStr.Database = "";// builder.Configuration.GetSection("NameDB").Value;
    string connectString = builderConnectStr.ConnectionString;
    builder.UseNpgsql(connectString);
    // a.GetService<Config>().ConnectString;
}, ServiceLifetime.Singleton);
builder.Services.AddTransient<Buffer_api>(a =>
{
    return new Buffer_api(a.GetService<Config>().Token);
});
builder.Services.AddTransient<IProviderInfoTags, TagsInfoService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<Stopwatch>(a =>
{
    var watch = new Stopwatch();
    watch.Start();
    return watch;
});
builder.Services.AddTransient<UpdateTags>();
//builder.Services.AddSingleton<HttpClient>();
var app = builder.Build();

app.Run();
