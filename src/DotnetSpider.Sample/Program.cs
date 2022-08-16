﻿using System;
using System.Threading;
using System.Threading.Tasks;
using DotnetSpider.Sample.samples;
using DotnetSpider.Scheduler;
using DotnetSpider.Scheduler.Component;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DotnetSpider.Sample
{
	class Program
	{
		static async Task Main(string[] args)
		{
			ThreadPool.SetMaxThreads(255, 255);
			ThreadPool.SetMinThreads(255, 255);

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
				.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
				.MinimumLevel.Override("System", LogEventLevel.Warning)
				.MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Warning)
				.Enrich.FromLogContext()
				.WriteTo.Console().WriteTo.RollingFile("logs/spider.log")
				.CreateLogger();


			// // await DistributedSpider.RunAsync();
			// await ProxySpider.RunAsync();
			// await EntitySpider.RunMySqlQueueAsync();
			//var builder = Builder.CreateDefaultBuilder<GithubSpider>(options =>
			//{
			//	// 每秒 1 个请求
			//	options.Speed = 1;
			//});
			//builder.UseSerilog();
			//builder.UseQueueDistinctBfsScheduler<HashSetDuplicateRemover>();
			//await builder.Build().RunAsync();
			await ImageSpider.RunAsync();

			Console.WriteLine("Bye!");
		}
	}
}
