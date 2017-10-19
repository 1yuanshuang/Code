using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLibrary
{
    public class DataFactory
    {
        /// <summary>
        /// 随机数据产生器
        /// </summary>
        static Random random = new Random();        

        /// <summary>
        /// 根据参数获取设备状态
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static DeviceStatus GetStatus(int intValue)
        {
            return intValue % 2 == 0 ? DeviceStatus.Off : DeviceStatus.Connected;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static String GetName(int intValue)
        {
            string refValue = "路由器";
            if (intValue % 3 == 0)
            {
                refValue = "路由器";
            }
            else if (intValue % 3 == 1)
            {
                refValue = "交换机";
            }
            else
            {
                refValue = "集线器";
            }
            return refValue;
        }

        /// <summary>
        /// 根据参数创建设备（简单工厂-参数工厂）
        /// </summary>
        /// <param name="typeValue"></param>
        /// <returns></returns>
        public static Device DeviceFactory(int typeValue)
        {
            Device refEntity = null;
            if (typeValue % 3 == 0)
            {
                refEntity = new Router();
            }
            else if (typeValue % 3 == 1)
            {
                refEntity = new Switcher();
            }
            else
            {
                refEntity = new Concentrator();
            }
            return refEntity;
        }

        /// <summary>
        /// 随即获取基类设备数据
        /// </summary>
        /// <param name="level">当前节点所在层</param>
        /// <param name="MaxLevel">树最大深度</param>
        /// <returns>设备树</returns>
        public static List<Device> GetBaseTypeDevices(int level, int MaxLevel)
        {
            level++;
            var count = random.Next(6, 10);
            List<Device> listTo = new List<Device>();
            for (int i = 1; i < count; i++)
            {
                Device entity = new Device();
                var typeValue = random.Next(1, 6);
                entity.Name = GetName(typeValue);
                entity.ImageUrl = "..\\..\\Resource\\" + entity.Name + ".png";
                entity.Status = GetStatus(typeValue);
                if (level <= MaxLevel)
                    entity.ChildNodes = GetBaseTypeDevices(level, MaxLevel);
                listTo.Add(entity);
            }
            return listTo;
        }

        /// <summary>
        /// 随即获取所有子类型设备数据
        /// </summary>
        /// <param name="level">当前节点所在层</param>
        /// <param name="MaxLevel">树最大深度</param>
        /// <returns>设备树</returns>
        public static List<Device> GetAllTypeDevice(int level,int MaxLevel)
        {
            level++;
            var count = random.Next(6, 10);
            List<Device> listTo = new List<Device>();
            for (int i = 1; i < count; i++)
            {
                var typeValue = random.Next(1, 6);
                Device entity = DeviceFactory(typeValue);                
                entity.Name = GetName(typeValue);
                entity.ImageUrl = "..\\..\\Resource\\" + entity.Name + ".png";
                entity.Status = GetStatus(typeValue); 
                if (level <= MaxLevel)
                    entity.ChildNodes = GetAllTypeDevice(level,MaxLevel);
                listTo.Add(entity);
            }
            return listTo;
        }

        /// <summary>
        /// 随即获取所有子类型设备数据
        /// </summary>
        /// <param name="level">当前节点所在层</param>
        /// <param name="MaxLevel">树最大深度</param>
        /// <param name="parentNode">父节点</param>
        /// <returns>设备树</returns>
        public static List<Device> GetAllTypeDevice(int level, int MaxLevel, Device parentNode)
        {
            level++;
            var count = random.Next(6, 10);
            List<Device> listTo = new List<Device>();
            for (int i = 1; i < count; i++)
            {
                var typeValue = random.Next(1, 6);
                Device entity = DeviceFactory(typeValue);
                entity.IsSelected = false;
                entity.Name = GetName(typeValue);
                entity.ParentNode = parentNode;
                entity.ImageUrl = "..\\..\\Resource\\" + entity.Name + ".png";
                entity.Status = GetStatus(typeValue);               
                if (level <= MaxLevel)
                    entity.ChildNodes = GetAllTypeDevice(level, MaxLevel, entity);
                listTo.Add(entity);
            }
            return listTo;
        }
    }
}
