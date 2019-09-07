using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityEngine.Networking
{
    public class ConnectNetwork : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button create;
        public Button search;
         NetworkManager manager;

        void Awake()
        {
            manager = GetComponent<NetworkManager>();
        }
        void Start()
        {

            manager.StartMatchMaker();
            //try
            //{
            //    manager.matchMaker.DestroyMatch(manager.matches[0].networkId, 0, manager.OnDestroyMatch);
            //}
            //catch
            //{
            //    Debug.Log("fallo al borrar");
            //}
            }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void CreateClick()
        {
            manager.matchMaker.CreateMatch("default", manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);
            DeactivateButtons();

        }
        public void SearchClick()
        {
            manager.matchMaker.ListMatches(0, 20, "", false, 0, 0, manager.OnMatchList);

            manager.matchMaker.JoinMatch(manager.matches[0].networkId, "", "", "", 0, 0, manager.OnMatchJoined);
            DeactivateButtons();
        }
        void DeactivateButtons()
        {
            create.gameObject.SetActive(false);
            search.gameObject.SetActive(false);
        }
        private void OnApplicationQuit()
        {
            manager.matchMaker.DestroyMatch(manager.matches[0].networkId, 0, manager.OnDestroyMatch);

        }
    }
}
