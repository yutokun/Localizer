namespace yutoVR.Localizer
{
	public interface IInjector
	{
		void Inject<T>(T localizedData);
	}
}
