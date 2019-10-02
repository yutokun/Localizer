namespace yutoVR.Localizer
{
	public interface IInjector
	{
		string Id { get; }
		void Inject(string text);
	}
}