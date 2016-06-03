Imports System.Windows.Controls.Primitives


Public Class WatermarkTextBox
    Inherits TextBox

#Region "Constructors"
    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(WatermarkTextBox), New FrameworkPropertyMetadata(GetType(WatermarkTextBox)))
    End Sub

#End Region

#Region "Properties"

#Region "SelectAllOnGotFocus (Obsolete)"

    Public Shared ReadOnly SelectAllOnGotFocusProperty As DependencyProperty = DependencyProperty.Register("SelectAllOnGotFocus", GetType(Boolean), GetType(WatermarkTextBox), New PropertyMetadata(False))
    Public Property SelectAllOnGotFocus() As Boolean
        Get
            Return CBool(GetValue(SelectAllOnGotFocusProperty))
        End Get
        Set(value As Boolean)
            SetValue(SelectAllOnGotFocusProperty, value)
        End Set
    End Property

#End Region

#Region "Watermark"

    Public Shared ReadOnly WatermarkProperty As DependencyProperty = DependencyProperty.Register("Watermark", GetType(Object), GetType(WatermarkTextBox), New UIPropertyMetadata(Nothing))
    Public Property Watermark() As Object
        Get
            Return DirectCast(GetValue(WatermarkProperty), Object)
        End Get
        Set(value As Object)
            SetValue(WatermarkProperty, value)
        End Set
    End Property

#End Region

#Region "WatermarkTemplate"

    Public Shared ReadOnly WatermarkTemplateProperty As DependencyProperty = DependencyProperty.Register("WatermarkTemplate", GetType(DataTemplate), GetType(WatermarkTextBox), New UIPropertyMetadata(Nothing))
    Public Property WatermarkTemplate() As DataTemplate
        Get
            Return DirectCast(GetValue(WatermarkTemplateProperty), DataTemplate)
        End Get
        Set(value As DataTemplate)
            SetValue(WatermarkTemplateProperty, value)
        End Set
    End Property

#End Region

#End Region



#Region "Base Class Overrides"

    Protected Overrides Sub OnGotFocus(e As RoutedEventArgs)
        MyBase.OnGotFocus(e)

        If SelectAllOnGotFocus Then
            Me.SelectAll()
        End If
    End Sub

    Protected Overrides Sub OnPreviewMouseLeftButtonDown(e As MouseButtonEventArgs)
        If Not IsKeyboardFocused AndAlso SelectAllOnGotFocus Then
            e.Handled = True
            Focus()
        End If

        MyBase.OnPreviewMouseLeftButtonDown(e)
    End Sub

#End Region
End Class
