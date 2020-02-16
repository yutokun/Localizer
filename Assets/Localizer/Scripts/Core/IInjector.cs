namespace yutoVR.Localizer
{
	public interface IInjector
	{
		void Inject<T1, T2>(T1 localizedData, T2 localizer) where T2 : LocalizerBase;
	}
}
