using System.Collections.Generic;
using Godot;

namespace MartiansDutyCS.scripts.Systems;

public partial class AudioManager : Node
{
    private static AudioManager _instance;
    private Dictionary<string, AudioStream> _audioStreams = new Dictionary<string, AudioStream>();
    
    private AudioManager() {}

    public static AudioManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AudioManager();
        }

        return _instance;
    }

    public void PlaySound(string fileName, Node parent, bool loop = false, int volume = 0)
    {
        if (!_audioStreams.ContainsKey(fileName))
        {
            var stream = GD.Load<AudioStream>(fileName);
            _audioStreams.Add(fileName, stream);
        }

        var player = new AudioStreamPlayer2D();
        player.Stream = _audioStreams[fileName];
        player.VolumeDb = volume;
        parent.AddChild(player);
        player.Play();

        if (!loop)
        {
            player.Finished += () => player.QueueFree();
        }

        if (loop)
        {
            player.Finished += () => PlaySound(fileName, parent, true);
        }
    }

}