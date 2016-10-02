using System;

namespace Siren
{
    class Worker
    {
        #region Declarations

        public static byte[] Kernel;
        public static byte[] CheckKernel;

        public static int ItemsDataOffset = -1;
        public static int OffsetToItemsSelected = -1;

        public static ItemsData GetSelectedItemsData;

        public struct ItemsData
        {
            public ushort Price;
            public ushort SellPriceMult;
        }

        #endregion

        #region WORD functions

        private static void Price(uint a, int add)
        {
            byte[] bytes = BitConverter.GetBytes(a / 10);
            Array.Copy(bytes, 0, Kernel, OffsetToItemsSelected + add, 2);
        }

        #endregion

        #region Update Variables

        public static void UpdateVariables(int index, object variable)
        {
            if (!Form1._loaded || Kernel == null)
                return;
            switch (index)
            {
                case 0:
                    Price(Convert.ToUInt32(variable), 0);
                    return;
                case 1:
                    Kernel[OffsetToItemsSelected + 2] = Convert.ToByte(variable);
                    return;
            }
        }

        #endregion

        #region Read Variables

        public static void ReadKernel(byte[] kernel)
        {
            Kernel = kernel;
            ItemsDataOffset = 0;
        }

        public static void ReadItems(int ItemsID_List)
        {
            GetSelectedItemsData = new ItemsData();
            ItemsID_List++; //skip dummy entry
            int selectedItemsOffset = ItemsDataOffset + (ItemsID_List * 4);
            OffsetToItemsSelected = selectedItemsOffset;

            GetSelectedItemsData.Price = BitConverter.ToUInt16(Kernel, selectedItemsOffset);
            GetSelectedItemsData.SellPriceMult = BitConverter.ToUInt16(Kernel, selectedItemsOffset + 2);
        }

        #endregion
    }
}
