using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Urbano_WPF.Enums;

namespace Urbano_WPF.Views.MessageBoxCustom
{
    /// <summary>
    /// Interaction logic for MessageBoxCustom.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        private MessageDialogButtonType type = MessageDialogButtonType.Ok;

        public MessageBoxCustom()
        {
            InitializeComponent();
        }

        public MessageBoxCustom(string Message, MessageType Type, MessageDialogButtonType Buttons)
        {
            type = Buttons;
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {

                case MessageType.Info:
                    txtTitle.Text = "Thông tin";
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Xác nhận";
                    break;
                case MessageType.Success:
                    txtTitle.Text = "Thành công";
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Cảnh báo";
                    break;
                case MessageType.Error:
                    txtTitle.Text = "Lỗi";
                    break;
            }
            switch (Buttons)
            {
                case MessageDialogButtonType.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Collapsed;
                    btnOk.Focus();
                    break;
                case MessageDialogButtonType.YesNo:
                    btnOk.Visibility = Visibility.Collapsed;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Focus();
                    break;
                case MessageDialogButtonType.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Collapsed;
                    btnOk.Focus();
                    break;
            }
        }

        public MessageBoxCustom(string Message, string Caption, MessageDialogButtonType Buttons)
        {
            type = Buttons;
            InitializeComponent();
            txtMessage.Text = Message;
            txtTitle.Text = Caption;
            switch (Buttons)
            {
                case MessageDialogButtonType.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Collapsed;
                    btnYes.Focus();
                    break;
                case MessageDialogButtonType.YesNo:
                    btnOk.Visibility = Visibility.Collapsed;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnOk.Focus();
                    break;
                case MessageDialogButtonType.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Collapsed;
                    btnOk.Focus();
                    break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                if (type == MessageDialogButtonType.Ok)
                    btnOk.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                if (type == MessageDialogButtonType.OkCancel)
                    btnOk.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                if (type == MessageDialogButtonType.YesNo)
                    btnYes.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.Escape)
            {
                e.Handled = true;
                if (type == MessageDialogButtonType.Ok)
                    btnOk.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                if (type == MessageDialogButtonType.OkCancel)
                    btnCancel.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                if (type == MessageDialogButtonType.YesNo)
                    btnNo.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public static bool? Show(string Message, string Caption, MessageDialogButtonType Buttons)
        {
            return new MessageBoxCustom(Message, Caption, Buttons).ShowDialog();
        }

        public static bool? Show(string Message, MessageType Type, MessageDialogButtonType Buttons)
        {
            return new MessageBoxCustom(Message, Type, Buttons).ShowDialog();
        }

        public static bool? Show(string Message, string Caption)
        {
            return new MessageBoxCustom(Message, Caption, MessageDialogButtonType.Ok).ShowDialog();
        }

        public static bool? Show(string Message, MessageType Type)
        {
            return new MessageBoxCustom(Message, Type, MessageDialogButtonType.Ok).ShowDialog();
        }

        public static bool? Show(string Message)
        {
            return new MessageBoxCustom(Message, "", MessageDialogButtonType.Ok).ShowDialog();
        }
    }
}
