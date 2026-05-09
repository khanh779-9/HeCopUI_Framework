using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.ComponentModel.Design.Serialization;
using HeCopUI_Framework.Converter;

namespace HeCopUI_Framework.Structs
{
    [TypeConverter(typeof(CornerRadiusConverter))]
    [Serializable]
    public struct CornerRadius : IEquatable<CornerRadius>
    {
        private bool _all;
        private float _topLeft;
        private float _topRight;
        private float _bottomLeft;
        private float _bottomRight;

        public static readonly CornerRadius Empty = new CornerRadius(0f);

        public CornerRadius(float all)
        {
            _topLeft = _topRight = _bottomLeft = _bottomRight = all;
            _all = true;
            Debug_SanityCheck();
        }

        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight)
        {
            _topLeft = topLeft;
            _topRight = topRight;
            _bottomLeft = bottomLeft;
            _bottomRight = bottomRight;
            _all = topLeft == topRight && topLeft == bottomLeft && topLeft == bottomRight;
            Debug_SanityCheck();
        }

        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight, float offset) :
           this(topLeft + offset, topRight + offset, bottomLeft - offset, bottomRight - offset)
        {

        }




        [RefreshProperties(RefreshProperties.All)]
        public float All
        {
            get => _all ? _topLeft : -1f;
            set
            {
                if (!_all || _topLeft != value)
                {
                    _all = true;
                    _topLeft = _topRight = _bottomLeft = _bottomRight = value;
                }
                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float TopLeft
        {
            get => _topLeft;
            set
            {
                if (_all || _topLeft != value)
                {
                    _all = false;
                    _topLeft = value;
                }
                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float TopRight
        {
            get => _all ? _topLeft : _topRight;
            set
            {
                if (_all || _topRight != value)
                {
                    _all = false;
                    _topRight = value;
                }
                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float BottomLeft
        {
            get => _all ? _topLeft : _bottomLeft;
            set
            {
                if (_all || _bottomLeft != value)
                {
                    _all = false;
                    _bottomLeft = value;
                }
                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float BottomRight
        {
            get => _all ? _topLeft : _bottomRight;
            set
            {
                if (_all || _bottomRight != value)
                {
                    _all = false;
                    _bottomRight = value;
                }
                Debug_SanityCheck();
            }
        }

        public static CornerRadius Add(CornerRadius c1, CornerRadius c2) => c1 + c2;
        public static CornerRadius Subtract(CornerRadius c1, CornerRadius c2) => c1 - c2;

        public bool Equals(CornerRadius other) =>
            TopLeft == other.TopLeft && TopRight == other.TopRight &&
            BottomLeft == other.BottomLeft && BottomRight == other.BottomRight;

        public override bool Equals(object obj) => obj is CornerRadius other && Equals(other);
        //public override int GetHashCode() => HashCode.Combine(TopLeft, TopRight, BottomLeft, BottomRight);
        public override string ToString() =>
            $"{{TopLeft={TopLeft}, TopRight={TopRight}, BottomLeft={BottomLeft}, BottomRight={BottomRight}}}";

        public static CornerRadius operator +(CornerRadius c1, CornerRadius c2) =>
            new CornerRadius(c1.TopLeft + c2.TopLeft, c1.TopRight + c2.TopRight, c1.BottomLeft + c2.BottomLeft, c1.BottomRight + c2.BottomRight);

        public static CornerRadius operator -(CornerRadius c1, CornerRadius c2) =>
            new CornerRadius(c1.TopLeft - c2.TopLeft, c1.TopRight - c2.TopRight, c1.BottomLeft - c2.BottomLeft, c1.BottomRight - c2.BottomRight);

        private void Debug_SanityCheck()
        {
            if (_all)
            {
                Debug.Assert(All == TopLeft && TopLeft == TopRight && TopRight == BottomLeft && BottomLeft == BottomRight, "_all inconsistent");
            }
            else
            {
                Debug.Assert(All == -1f, "_all flag false but All != -1");
            }
        }

        internal bool ShouldSerializeAll() => _all;

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + TopLeft.GetHashCode();
                hash = hash * 23 + TopRight.GetHashCode();
                hash = hash * 23 + BottomLeft.GetHashCode();
                hash = hash * 23 + BottomRight.GetHashCode();
                return hash;
            }
        }

    }
}
