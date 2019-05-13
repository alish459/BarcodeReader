using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.CrudService
{
    public class InventoryCrud
    {
        public static List<Connection.Model.Inventory> ReturnAllGoods()
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                return context.Inventory.AsNoTracking().ToList();
            }
        }
        public static List<Connection.Services.GoodsService> ReturnAllGoodsByService()
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                return (from read in context.Inventory
                        select new Connection.Services.GoodsService
                        {
                            GoodsBarcode1 = read.Barcode1,
                            GoodsBarcode2 = read.Barcode2,
                            GoodsID = read.GoodsID,
                            GoodsName = read.Name,
                            Total = string.Empty,
                        }).ToList();
            }
        }
        public static bool Create(Connection.Model.Inventory AllGoodsInstance)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    context.Inventory.Add(AllGoodsInstance);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool Update(Connection.Model.Inventory ObjectName)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    var Ins = context.Inventory.Where(a => a.GoodsID == ObjectName.GoodsID).FirstOrDefault();
                    Ins.Name = ObjectName.Name;
                    Ins.Barcode1 = ObjectName.Barcode1;
                    Ins.Barcode2 = ObjectName.Barcode2;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool Delete(int ID)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    context.Inventory.Remove(context.Inventory.Find(ID));
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool CheckForRepetitive(string Code1, string Code2)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.Inventory.Any(a => a.Barcode1 == Code1 || a.Barcode2 == Code2);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool CheckForRepetitive(string Code1 , string Code2, int ID)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.Inventory.Any(a => (a.Barcode1 == Code1 || a.Barcode2 == Code2) && a.GoodsID != ID);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static string ReadByBarcode(string Code1, string Code2)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.Inventory.FirstOrDefault(a => a.Barcode1 == Code1 || a.Barcode2 == Code2).Name;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return string.Empty;
                }
            }
        }
        public static string ReadByBarcode(string Code1 , string Code2, int ID)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.Inventory.FirstOrDefault(a => (a.Barcode1 == Code1 || a.Barcode2 == Code2) && a.GoodsID != ID).Name;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return string.Empty;
                }
            }
        }
    }
}
