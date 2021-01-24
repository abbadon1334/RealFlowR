namespace FlowR.UI
{
    /*
    public abstract class BootstrapElement<T> : ComponentElement<T> where T : Component<T>
    {
        public abstract string baseCSSClassName { get; protected set; }

        public T SetBaseResponsive(ResponsiveViewports breakpoint, int size = 0)
        {
            RemoveCSSClass(baseCSSClassName);
                
            string newClass = baseCSSClassName + "-" + breakpoint.ToString().ToLower();
            
            AddCSSClass(newClass + (size > 0 ? "-" + size : ""));

            return DerivedClass;
        }
        
        public T AddResponsive(ResponsiveViewports breakpoint, int size)
        {
            string newClass = baseCSSClassName + "-" + breakpoint.ToString().ToLower();
            
            AddCSSClass(newClass + (size > 0 ? "-" + size : ""));

            return DerivedClass;
        }
        
        public T AddOffset(ResponsiveViewports breakpoint, int size)
        {
            AddCSSClass("offset-" + breakpoint.ToString().ToLower() + "-" + size);

            return DerivedClass;
        }

        public T SetFlexAlign(FlexBoxAlign.Items align)
        {
            AddCSSClass("align-items-" + align.ToString().ToLower());

            return DerivedClass;
        }
        
        public T SetFlexAlign(FlexBoxAlign.Self align)
        {
            AddCSSClass("align-self-" + align.ToString().ToLower());

            return DerivedClass;
        }
        
        public T SetFlexAlign(FlexBoxAlign.Content align)
        {
            AddCSSClass("justify-content-" + align.ToString().ToLower());

            return DerivedClass;
        }

        public T SetGutter(int gutter)
        {
            AddCSSClass("g-" + gutter);

            return DerivedClass;
        }

        public T SetGutterVertical(int gutter)
        {
            AddCSSClass("gy-" + gutter);

            return DerivedClass;
        }
        
        public T SetGutterHorizontal(int gutter)
        {
            AddCSSClass("gx-" + gutter);

            return DerivedClass;
        }

        public T SetDisplayFlex()
        {
            AddCSSClass("d-flex");

            return DerivedClass;
        }
    }
    */
}