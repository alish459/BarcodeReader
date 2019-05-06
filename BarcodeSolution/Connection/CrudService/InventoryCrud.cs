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
                    Ins.Barcode = ObjectName.Barcode;
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
    }
}
