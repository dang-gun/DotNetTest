
using System.Reactive.Joins;
using System.Runtime.CompilerServices;

using OpenTK.Audio;
using OpenTK.Audio.OpenAL;


namespace Net6LinuxTest2;

internal class Program
{
	static readonly string filename1 = Path.Combine(Path.Combine("Files"), @"Test1.wav");

	static readonly string filename2 = Path.Combine(Path.Combine("Files"), @"Test2.wav");

	static void Main(string[] args)
	{
		//AudioContext context = new AudioContext();

		Console.WriteLine("Hello, World!");

		Play(filename1);

		Thread.Sleep(5000);

		Console.WriteLine("------- Exit Agent ------");
		Console.WriteLine("------- 'R' 을 눌러 프로그램 종료 ------");

		ConsoleKeyInfo keyinfo;
		do
		{
			keyinfo = Console.ReadKey();
		} while (keyinfo.Key != ConsoleKey.R);
	}

	public static void Play(string sFileName)
	{
		var device = ALC.OpenDevice(null);
		var context = ALC.CreateContext(device, new ALContextAttributes());
		ALC.MakeContextCurrent(context);

		int bufferId = AL.GenBuffer();
		int sourceId = AL.GenSource();

		int channels, bits_per_sample, sample_rate;
		byte[] soundData = LoadWave(
			File.Open(sFileName, FileMode.Open),
			out channels,
			out bits_per_sample,
			out sample_rate);
		AL.BufferData(bufferId
			, GetSoundFormat(channels, bits_per_sample)
			, soundData
			, bits_per_sample);

		// AL.Listener(ALListener3f.Position, 0.0f, 0.0f, 0.0f);
		// AL.Listener(ALListener3f.Velocity, 0.0f, 0.0f, 0.0f);

		
		// AL.Source(sourceId, ALSourcef.Gain, 1);
		// AL.Source(sourceId, ALSourcef.Pitch, 1);
		// AL.Source(sourceId, ALSource3f.Position, 0.0f, 0.0f, 0.0f);

		AL.Source(sourceId, ALSourcei.Buffer, bufferId);
		AL.Source(sourceId, ALSourceb.Looping, true);
		AL.SourcePlay(sourceId);
	}


	// Loads a wave/riff audio file..
	public static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
	{
		if (stream == null)
			throw new ArgumentNullException("stream");

		using (BinaryReader reader = new BinaryReader(stream))
		{
			// RIFF header
			string signature = new string(reader.ReadChars(4));
			if (signature != "RIFF")
				throw new NotSupportedException("Specified stream is not a wave file.");

			int riff_chunck_size = reader.ReadInt32();

			string format = new string(reader.ReadChars(4));
			if (format != "WAVE")
				throw new NotSupportedException("Specified stream is not a wave file.");

			// WAVE header
			string format_signature = new string(reader.ReadChars(4));
			if (format_signature != "fmt ")
				throw new NotSupportedException("Specified wave file is not supported.");

			int format_chunk_size = reader.ReadInt32();
			int audio_format = reader.ReadInt16();
			int num_channels = reader.ReadInt16();
			int sample_rate = reader.ReadInt32();
			int byte_rate = reader.ReadInt32();
			int block_align = reader.ReadInt16();
			int bits_per_sample = reader.ReadInt16();

			string data_signature = new string(reader.ReadChars(4));
			if (data_signature != "data")
				throw new NotSupportedException("Specified wave file is not supported.");

			int data_chunk_size = reader.ReadInt32();

			channels = num_channels;
			bits = bits_per_sample;
			rate = sample_rate;

			return reader.ReadBytes((int)reader.BaseStream.Length);
		}
	}

	public static ALFormat GetSoundFormat(int channels, int bits)
	{
		switch (channels)
		{
			case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
			case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
			default: throw new NotSupportedException("The specified sound format is not supported.");
		}
	}
}