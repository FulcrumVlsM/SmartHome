using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.EF.Configurations;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF
{
    internal class AppDatabaseContext : DbContext
    {
        //Устройства
        public DbSet<BoolActionDevice> BoolActionDevices { get; set; }
        public DbSet<BoolSensor> BoolSensors { get; set; }
        public DbSet<EventDevice> EventDevices { get; set; }
        public DbSet<NumericSensor> NumericSensors { get; set; }

        //Условия
        public DbSet<BoolDeviceEventAction> BoolDeviceEventActions { get; set; }
        public DbSet<BoolSensorCondition> BoolSensorConditions { get; set; }
        public DbSet<NumericSensorCondition> NumericSensorConditions { get; set; }
        public DbSet<TimeCondition> TimeConditions { get; set; }
        
        //Правила
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleNode> RuleNodes { get; set; }

        //Логи работы устройств
        public DbSet<BoolActionDeviceHistory> BoolActionDeviceHistory { get; set; }
        public DbSet<BoolSensorHistory> BoolSensorHistory { get; set; }
        public DbSet<EventDeviceHistory> EventDeviceHistory { get; set; }
        public DbSet<NumericSensorHistory> NumericSensorHistory { get; set; }

        //Пользователи и СКУД
        public DbSet<User> Users { get; set; }
        public DbSet<SmartCard> SmartCards { get; set; }
        public DbSet<UserCondition> UserConditions { get; set; }
        public DbSet<UserActionHistory> UserActionHistory { get; set; }


        public AppDatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoolActionDeviceConfiguration());
            modelBuilder.ApplyConfiguration(new BoolActionDeviceHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new BoolDeviceEventActionConfiguration());
            modelBuilder.ApplyConfiguration(new BoolSensorConfiguration());
            modelBuilder.ApplyConfiguration(new BoolSensorConditionConfiguration());
            modelBuilder.ApplyConfiguration(new BoolSensorHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new EventDeviceConfiguration());
            modelBuilder.ApplyConfiguration(new EventDeviceHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new NumericSensorConfiguration());
            modelBuilder.ApplyConfiguration(new NumericSensorConditionConfiguration());
            modelBuilder.ApplyConfiguration(new NumericSensorHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new RuleConfiguration());
            modelBuilder.ApplyConfiguration(new Rule2BoolActionDeviceConfiguration());
            modelBuilder.ApplyConfiguration(new Rule2EventDeviceConfiguration());
            modelBuilder.ApplyConfiguration(new RuleNodeConfiguration());
            modelBuilder.ApplyConfiguration(new SmartCardConfiguration());
            modelBuilder.ApplyConfiguration(new TimeConditionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserActionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConditionConfiguration());
        }
    }
}
