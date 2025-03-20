' NOTE: This form is inherited from the CaptureForm,
' so the VisualStudio Form Designer may not load this properly
' (at least until you build the project).
' If you want to make changes in the form layout - do it in the base CaptureForm.
' All changes in the CaptureForm will be reflected in all derived forms 
' (i.e. in the EnrollmentForm and in the VerificationForm)

Public Class EnrollmentForm
    Inherits CaptureForm

    Friend WithEvents Lblced As Label
    Friend WithEvents Label1 As Label
    Public Event OnTemplate(ByVal template)

    Private Enroller As DPFP.Processing.Enrollment

    Protected Overrides Sub Init()
        MyBase.Init()
        MyBase.Text = "Fingerprint Enrollment"
        Enroller = New DPFP.Processing.Enrollment()     ' Create an enrollment.
        UpdateStatus()
    End Sub

    Protected Overrides Sub Process(ByVal Sample As DPFP.Sample)
        MyBase.Process(Sample)

        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

        ' Check quality of the sample and add to enroller if it's good
        If (Not features Is Nothing) Then
            Try
                MakeReport("The fingerprint feature set was created.")
                Enroller.AddFeatures(features)        ' Add feature set to template.
            Finally
                UpdateStatus()

                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready    ' Report success and stop capturing
                        RaiseEvent OnTemplate(Enroller.Template)
                        SetPrompt("Click Close, and then click Fingerprint Verification.")
                        StopCapture()

                    Case DPFP.Processing.Enrollment.Status.Failed   ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
                        RaiseEvent OnTemplate(Nothing)
                        StartCapture()

                End Select
            End Try
        End If
    End Sub

    Protected Sub UpdateStatus()
        ' Show number of samples needed.
        SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded))
    End Sub

    Private Sub InitializeComponent()
        Me.Lblced = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lblced
        '
        Me.Lblced.AutoSize = True
        Me.Lblced.Location = New System.Drawing.Point(303, 332)
        Me.Lblced.Name = "Lblced"
        Me.Lblced.Size = New System.Drawing.Size(10, 13)
        Me.Lblced.TabIndex = 17
        Me.Lblced.Text = "."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Número  de Cédula Validado:"
        '
        'EnrollmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(581, 354)
        Me.Controls.Add(Me.Lblced)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EnrollmentForm"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Lblced, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
