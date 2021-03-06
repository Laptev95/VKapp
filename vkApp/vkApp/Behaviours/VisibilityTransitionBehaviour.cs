﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace vkApp.Behaviours
{
    public class VisibilityTransitionBehaviour : Behavior<FrameworkElement>
    {

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(Visibility), typeof(VisibilityTransitionBehaviour), new PropertyMetadata(default(Visibility), PropertyChangedCallback));

        public Visibility Value
        {
            get { return (Visibility)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var b = (VisibilityTransitionBehaviour)d;

            b.TransitionOut((Visibility)e.OldValue);
        }


        public static readonly DependencyProperty AnimationOutProperty =
            DependencyProperty.Register("AnimationOut", typeof(Storyboard), typeof(VisibilityTransitionBehaviour), new PropertyMetadata(default(Storyboard)));

        public Storyboard AnimationOut
        {
            get { return (Storyboard)GetValue(AnimationOutProperty); }
            set { SetValue(AnimationOutProperty, value); }
        }

        public static readonly DependencyProperty AnimationInProperty =
            DependencyProperty.Register("AnimationIn", typeof(Storyboard), typeof(VisibilityTransitionBehaviour), new PropertyMetadata(default(Storyboard)));

        public Storyboard AnimationIn
        {
            get { return (Storyboard)GetValue(AnimationInProperty); }
            set { SetValue(AnimationInProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.Visibility = Value;

            base.OnAttached();
        }

        private void TransitionOut(Visibility oldValue)
        {
            if (AssociatedObject == null)
                return;

            if (AnimationOut == null || oldValue == Visibility.Collapsed)
            {
                TransitionIn();
            }
            else
            {
                AnimationOut.Completed += AnimationOutCompleted;
                AnimationOut.Begin(AssociatedObject);
            }
        }

        private void TransitionIn()
        {
            if (AssociatedObject == null)
                return;

            AssociatedObject.Visibility = Value;
            if (AnimationIn != null)
            {
                AnimationIn.Begin(AssociatedObject);
            }
        }
        void AnimationOutCompleted(object sender, object e)
        {
            AnimationOut.Completed -= AnimationOutCompleted;
            TransitionIn();
        }
    }
}
