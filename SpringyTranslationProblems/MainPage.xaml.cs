using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpringyTranslationProblems
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
	    private Compositor _compositor;
	    private SpringVector3NaturalMotionAnimation _springLeftAnimation;
	    private SpringVector3NaturalMotionAnimation _springRightAnimation;
	    private SpringVector3NaturalMotionAnimation _springRightABitAnimation;

	    public MainPage()
        {
            this.InitializeComponent();

	        this.Loaded += (_, __) =>
	        {
		        _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor; 

		        ElementCompositionPreview.SetIsTranslationEnabled(MoveableRectangle, true);


		        _springLeftAnimation = _compositor.CreateSpringVector3Animation();
		        _springLeftAnimation.Period = TimeSpan.FromMilliseconds(30);
		        _springLeftAnimation.DampingRatio = 0.5f;
		        _springLeftAnimation.FinalValue = new Vector3(-300, 0, 0);

		        _springRightAnimation = _compositor.CreateSpringVector3Animation();
		        _springRightAnimation.Period = TimeSpan.FromMilliseconds(30);
		        _springRightAnimation.DampingRatio = 0.5f;
		        _springRightAnimation.FinalValue = new Vector3(0, 0, 0);

		        _springRightABitAnimation = _compositor.CreateSpringVector3Animation();
		        _springRightABitAnimation.Period = TimeSpan.FromMilliseconds(30);
		        _springRightABitAnimation.DampingRatio = 0.5f;
		        _springRightABitAnimation.FinalValue = new Vector3(-1, 0, 0);

	        };

	        MoveLeftButton.Click += (_, __) =>
	        {
				ElementCompositionPreview.GetElementVisual(MoveableRectangle).StartAnimation("Translation", _springLeftAnimation);
	        };

	        MoveRightButton.Click += (_, __) =>
	        {
		        ElementCompositionPreview.GetElementVisual(MoveableRectangle).StartAnimation("Translation", _springRightAnimation);
	        };	        
	        
	        MoveRightABitButton.Click += (_, __) =>
	        {
		        ElementCompositionPreview.GetElementVisual(MoveableRectangle).StartAnimation("Translation", _springRightABitAnimation);
	        };


        }
    }
}
