using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Urbano_WPF.Helper;
using Urbano_WPF.Models;
using Urbano_WPF.Views.MessageBoxCustom;

namespace Urbano_WPF.ViewModels.Employee
{
    public partial class EmployeeViewModel : ObservableObject
    {
        public ObservableCollection<NhanVien> NhanVien { get; set; } = new ObservableCollection<NhanVien>();


        public EmployeeViewModel() 
        {
            _ = GetData();
        }

        public async Task GetData()
        {
            try
            {
                using(var db = new UrbanoDbContext())
                {
                    var employList = await db.NhanViens.ToListAsync();

                    foreach(var item in  employList)
                    {
                        NhanVien.Add(item);
                    }

                    MessageBoxCustom.Show($"Số nhân viên: {NhanVien.Count()}", Enums.MessageType.Info);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
        }
    }
}
