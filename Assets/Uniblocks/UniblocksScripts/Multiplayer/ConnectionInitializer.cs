using UnityEngine;

namespace Uniblocks
{
    public class ConnectionInitializer : MonoBehaviour
    {
        public GameObject UniblocksNetworkPrefab;
        public bool ConnectToServerOnAwake, StartServerOnAwake;

        public string ServerIP, ServerPassword;
        public int Port, MaxConnections;
        public bool UseNat;


        void LateUpdate()
        {
            if (StartServerOnAwake)
            {
                StartServer();
            }
            else if (ConnectToServerOnAwake)
            {
                ConnectToServer();
            }
            this.enabled = false;
        }

        public void StartServer()
        {
            //TODO: robert Network.InitializeServer(MaxConnections, Port, UseNat);
        }

        void OnServerInitialized()
        {
            //TODO: robert Network.Instantiate(UniblocksNetworkPrefab, transform.position, transform.rotation, 0); // instantiate UniblocksNetwork
        }

        public void ConnectToServer()
        {
            //TODO: robert Network.Connect(ServerIP, Port, ServerPassword);
        }
    }
}