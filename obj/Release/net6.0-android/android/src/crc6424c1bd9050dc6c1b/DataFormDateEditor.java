package crc6424c1bd9050dc6c1b;


public class DataFormDateEditor
	extends crc6424c1bd9050dc6c1b.DataFormEditorBase_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Editors.DataForm.Editors.DataFormDateEditor, DevExpress.Maui.Editors", DataFormDateEditor.class, __md_methods);
	}


	public DataFormDateEditor (android.view.View p0)
	{
		super (p0);
		if (getClass () == DataFormDateEditor.class)
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.DataForm.Editors.DataFormDateEditor, DevExpress.Maui.Editors", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public DataFormDateEditor (android.view.View p0, com.devexpress.editors.dataForm.protocols.DXDataFormEditorItemErrorProvider p1)
	{
		super (p0, p1);
		if (getClass () == DataFormDateEditor.class)
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.DataForm.Editors.DataFormDateEditor, DevExpress.Maui.Editors", "Android.Views.View, Mono.Android:Com.Devexpress.Editors.DataForm.Protocols.DXDataFormEditorItemErrorProvider, DevExpress.Maui.Android.Editors", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
