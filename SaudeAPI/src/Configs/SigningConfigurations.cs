using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SaudeAPI.Configs
{
    public class SigningConfigurations
    {
        public SymmetricSecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("eZ-6QNKvgp8:APA91bH2IYgO31CdPowpCbGO5QRGiZQs4sg6VYdjsLH6PydiLr79xkBMWzTFJY49Pv0DNUfhSIqSnvf9LkQZyNATfLZwVXXgVxp_BuTTv55a6qtFVr5SzxspOMdpMKJaA-MTKT2Lopom"));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }

    public class RecoverConfigurations
    {
        public SymmetricSecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public RecoverConfigurations()
        {
            Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ecgXxV99/eEkyZ3UmK5A+9ptdflAE92CphbCMtzsK7wrtE86MA2XcwnOYKJ/cSk07gV5QWo8aljOfuukq+Uy8z9mgLn5cKlGUZj1vg9l82inO/JIDedWtUdjtUQyePTf"));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}