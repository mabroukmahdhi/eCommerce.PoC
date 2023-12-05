// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Platform;

namespace SaarWorld.Brokers.Handlers.EditorHandlers
{
    public class EditorHandlerBroker : IEditorHandlerBroker
    {
        public void AppendEditorsToMapping()
        {
            AppendBorderlessEntryToMapping();
            AppendBorderlessPickerToMapping();
        }

        private void AppendBorderlessEntryToMapping()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
                if (view is Entry)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            });
        }

        private void AppendBorderlessPickerToMapping()
        {
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(Picker), (handler, view) =>
            {
                if (view is Picker)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            });
        }
    }
}