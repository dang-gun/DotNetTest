
using System.Reactive.Joins;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;


namespace Net6LinuxTest2;

/// <summary>
/// OpenTK.OpenAL 4.7.7
/// 우분투에서 테스트함
/// </summary>
internal class Program
{
    /// <summary>
    /// 테스트 파일 1
    /// </summary>
    static readonly string filename1 
		= Path.Combine(Path.Combine("Files"), @"Test1.wav");
    /// <summary>
    /// 테스트 파일 2
    /// </summary>
    static readonly string filename2 
		= Path.Combine(Path.Combine("Files"), @"Test2.wav");

    static void Main(string[] args)
	{

        ALDevice device = ALC.OpenDevice(null);

        List<string> list = ALC.GetString(AlcGetStringList.AllDevicesSpecifier);
        list.ForEach(f => { Console.WriteLine(f); });
        
        


        ALContext context = ALC.CreateContext(device, new ALContextAttributes());
        ALC.MakeContextCurrent(context);


        Play(filename1);
		Thread.Sleep(2000);
        Play(filename2);
        Thread.Sleep(2000);


        Console.WriteLine("------- Exit Agent ------");
		Console.WriteLine("------- 'R' 을 눌러 프로그램 종료 ------");

		ConsoleKeyInfo keyinfo;
		do
		{
			keyinfo = Console.ReadKey();
		} while (keyinfo.Key != ConsoleKey.R);
	}

	public static async void Play(string sFileName)
	{
        int bufferId = AL.GenBuffer();
        int sourceId = AL.GenSource();
        int state;

        int channels, bits_per_sample, sample_rate;

        //https://github.com/opentk/opentk/issues/1507
		//파일 로드
        byte[] sound_data = LoadWave(
			File.Open(sFileName, FileMode.Open)
			, out channels
			, out bits_per_sample
			, out sample_rate);

        //data를 비관리 포인터로 변환
        IntPtr unmanagedPointer = Marshal.AllocHGlobal(sound_data.Length);
        Marshal.Copy(sound_data, 0, unmanagedPointer, sound_data.Length);

        // 에러 확인
        Console.WriteLine(AL.GetError());


        

        //버퍼 작성
        AL.BufferData(
            bufferId
            , GetSoundFormat(channels, bits_per_sample)
            , unmanagedPointer
            , sound_data.Length
            , sample_rate);


        Console.WriteLine(AL.GetError()); // no error

        //소스 설정
        AL.Source(sourceId, ALSourcei.Buffer, bufferId);
        //AL.Source(sourceId, ALSourceb.Looping, true);
        //소스 재생
        AL.SourcePlay(sourceId);


		Console.WriteLine(string.Format("Playing[{0}][{1}]({2})"
							, sourceId
							, bufferId
							, sFileName));

        await Task.Run(() =>
        {
            //재생이 끝났는지 확인하는 루프
            do
            {
                Thread.Sleep(250);
                Console.Write(".");
                AL.GetSource(sourceId, ALGetSourcei.SourceState, out state);
            }//재생이 아니라면 루프를 끝낸다.
            while ((ALSourceState)state == ALSourceState.Playing);

            Console.WriteLine("Playing end : " + sourceId);

            AL.SourceStop(sourceId);
            AL.DeleteSource(sourceId);
            AL.DeleteBuffer(sourceId);

            // 비관리 포인터 해제
            Marshal.FreeHGlobal(unmanagedPointer);
        });

    }


    /// <summary>
    /// Loads a wave/riff audio file..
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="channels"></param>
    /// <param name="bits"></param>
    /// <param name="rate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
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