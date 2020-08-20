using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballPlayersHotbed.DAO;
using FootballPlayersHotbed.EFModels;
using FootballPlayersHotbed.Models;
using FootballPlayersHotbed.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Player = FootballPlayersHotbed.EFModels.Player;
using Representative = FootballPlayersHotbed.EFModels.Representative;
using Team = FootballPlayersHotbed.EFModels.Team;

namespace FootballPlayersHotbed
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<FootballPlayersHotbedContext>(option =>
            {
                option.UseSqlServer("Server=.\\sqlexpress;Database=FootballPlayersHotbed;trusted_connection=true");
            });
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IDbContextFootballPlayersHotbed, DAOFutballPlayersHotbed>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(conf =>
            {
                conf.CreateMap<Player, PlayerDTO>();
                conf.CreateMap<PlayerDTO,Player>();
                conf.CreateMap<Representative, RepresentativeDTO>();
                conf.CreateMap<RepresentativeDTO, Representative>();
                conf.CreateMap<Team, TeamDTO>();
                conf.CreateMap<TeamDTO, Team>();
                conf.CreateMap<ViewPlayerDTO, Player>();
                conf.CreateMap<Player, ViewPlayerDTO>();
                conf.CreateMap<ViewRepresentativeDTO, Representative>();
                conf.CreateMap<Representative, ViewRepresentativeDTO>();
                conf.CreateMap<ViewTeamDTO, Team>();
                conf.CreateMap<Team, ViewTeamDTO>();
                
            });

            app.UseMvc();
            
        }
    }
}
