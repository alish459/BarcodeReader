using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.CrudService
{
    public class InventoryCrud
    {
        public static List<Connection.Model.TblInventory> ReturnAllGoods()
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                return context.TblInventory.AsNoTracking().ToList();
            }
        }
        public static bool Create(Connection.Model.TblInventory AllGoodsInstance)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    context.TblInventory.Add(AllGoodsInstance);
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
        public static bool Update(Connection.Model.TblInventory ObjectName)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    var Ins = context.TblInventory.Where(a => a.Shka == ObjectName.Shka).FirstOrDefault();
                    Ins.Name = ObjectName.Name;
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
                    if (context.TblBarcode.Any(a=>a.GoodsID==ID))
                    {
                        System.Windows.Forms.MessageBox.Show("براي اين كالا باركد تعريف شده است، ابتدا باركدها را حذف نماييد");
                        return false;
                    }
                    context.TblInventory.Remove(context.TblInventory.Find(ID));
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
        public static bool CheckForRepetitive(string naka)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.TblInventory.Any(a => a.Name == naka);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool CheckForRepetitive(string naka, int ID)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.TblInventory.Any(a => (a.Name == naka) && a.Shka != ID);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static string ReadByBarcode(string naka)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.TblInventory.FirstOrDefault(a => a.Name == naka).Name;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    return string.Empty;
                }
            }
        }
        public static string ReadByBarcode(string naka, int ID)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    return context.TblInventory.FirstOrDefault(a => (a.Name == naka) && a.Shka != ID).Name;
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
