using Assets.PixelCrew.Scripts.Model.Definitions.Repositories;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.UIscripts.Widgets
{
    public class PredefinedDataGroup<TDataType, TItemType> : DataGroup<TDataType, TItemType>
        where TItemType : MonoBehaviour, IItemRenderer<TDataType>
    {
        public PredefinedDataGroup(Transform container) : base(null, container)
        {
            var items = container.GetComponentsInChildren<TItemType>();
            CreatedItems.AddRange(items);
        }

        public override void SetData(IList<TDataType> data)
        {
            if (data.Count > CreatedItems.Count)
                throw new IndexOutOfRangeException();

            base.SetData(data);
        }
    }
}