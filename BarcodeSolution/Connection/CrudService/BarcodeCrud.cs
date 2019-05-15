using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.CrudService
{
    public class BarcodeCrud
    {
        public static List<Connection.Model.TblBarcode> ReturnAllGoods()
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                return context.TblBarcode.AsNoTracking().ToList();
            }
        }
        public static List<Connection.Services.GoodsService> ReturnAllGoodsByService()
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                return (from read in context.TblBarcode
                        join read2 in context.TblInventory
                        on read.Shka equals read2.Shka
                        select new Connection.Services.GoodsService
                        {
                            GoodsBarcode1 = read.Barcode1,
                            GoodsBarcode2 = read.Barcode2,
                            GoodsID = read.Shka,
                            GoodsName = read2.Name,
                            Total = string.Empty,
                        }).ToList();
            }
        }
        public static bool Create(Connection.Model.TblBarcode AllGoodsInstance)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    context.TblBarcode.Add(AllGoodsInstance);
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
        public static bool Update(Connection.Model.TblBarcode ObjectName)
        {
            using (var context = new Connection.Model.BarcodeEntity())
            {
                try
                {
                    var Ins = context.TblBarcode.Where(a => a.RowID == ObjectName.RowID).FirstOrDefault();
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
                    context.TblBarcode.Remove(context.TblBarcode.Find(ID));
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
                    return context.TblBarcode.Any(a => a.Barcode1 == Code1 || a.Barcode2 == Code2);
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
                    return context.TblBarcode.Any(a => (a.Barcode1 == Code1 || a.Barcode2 == Code2) && a.Shka != ID);
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
                    return context.TblBarcode.FirstOrDefault(a => a.Barcode1 == Code1 || a.Barcode2 == Code2).Inventories.Name;
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
                    return context.TblBarcode.FirstOrDefault(a => (a.Barcode1 == Code1 || a.Barcode2 == Code2) && a.Shka != ID).Inventories.Name;
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
