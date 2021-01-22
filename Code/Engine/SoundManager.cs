using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Engine
{
	class SoundManager
	{
		private IDictionary<string, Song> Songs;
		private IDictionary<string, SoundEffect> SoundEffects;

		public SoundManager()
		{
			Songs = new Dictionary<string, Song>();
			SoundEffects = new Dictionary<string, SoundEffect>();
		}

		public void AddSong(string name, string newName = null)
		{
			Song newSong = GameState.Instance.GetContent().Load<Song>(name);

			name = newName != null ? newName : name;

			Songs.Add(name, newSong);
		}

		public Song GetSong(string name)
		{
			return Songs[name];
		}

		public void AddSoundEffect(string name, string newName = null)
		{
			SoundEffect newSondEffect = GameState.Instance.GetContent().Load<SoundEffect>(name);

			name = newName != null ? newName : name;

			SoundEffects.Add(name, newSondEffect);
		}

		public SoundEffect GetSoundEffect(string name)
		{
			return SoundEffects[name];
		}

		public void PlaySong(string name, bool isRepeating=true)
		{
			if (!Songs.ContainsKey(name))
			{
				Trace.WriteLine("WARNING: You tried to play song that was not loaded. Check if you spelled it correctly or forgot to load it in a scene");
				return;
			}

			MediaPlayer.Play(Songs[name]);
			MediaPlayer.IsRepeating = isRepeating;
		}

		public void StopSong()
		{
			MediaPlayer.Stop();
		}

		public void PlaySoundEffect(string name, bool isRepeating=false)
		{
			if (!SoundEffects.ContainsKey(name))
			{
				Trace.WriteLine("WARNING: You tried to play sound effect that was not loaded. Check if you spelled it correctly or forgot to load it in a scene");
				return;
			}

			SoundEffectInstance soundEffectInstance = SoundEffects[name].CreateInstance();
			soundEffectInstance.IsLooped = isRepeating;
			soundEffectInstance.Play();
		}
	}
}
