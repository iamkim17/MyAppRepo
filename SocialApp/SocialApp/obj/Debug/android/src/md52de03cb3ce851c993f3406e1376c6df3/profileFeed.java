package md52de03cb3ce851c993f3406e1376c6df3;


public class profileFeed
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SocialApp.profileFeed, SocialApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", profileFeed.class, __md_methods);
	}


	public profileFeed () throws java.lang.Throwable
	{
		super ();
		if (getClass () == profileFeed.class)
			mono.android.TypeManager.Activate ("SocialApp.profileFeed, SocialApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
