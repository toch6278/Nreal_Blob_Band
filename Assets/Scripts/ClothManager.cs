using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement; 
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class ClothManager : MonoBehaviour
{

    public List<GameObject> accessories; 
    public List<GameObject> tops; 
    public List<GameObject> pants; 
    public List<GameObject> shoes; 
    public List<GameObject> hair; 
 
    //test toggle
    public  GameObject obj;
    // public StudioManager gBlob; 
    public bool isEnabled = true; 

    public static ClothManager Instance; 
    public int A_index,T_index,P_index,H_index,S_index;
    //referenced WAR dd on Youtube
    public FlexibleColorPicker fcp; 
    public Material material; 
    public Color tempColor; 
    public float red, green, blue;
    // private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/"; 
    public string saveFile, saveFile_g, saveFile_d, saveFile_p;
    public bool isLoadCloth;
    public TextAsset saveJson; 
    private void Awake()
    { 
        // [SerializeField]
        // if(!Directory.Exists(SAVE_FOLDER))
        // {
        //    Directory.CreateDirectory(SAVE_FOLDER); 
        // }
        // else
        // {
        //    File.WriteAllText(Application.dataPath + "/save.txt", json); 
        // }
    }
    // Start is called before the first frame update
    void Start()
    {
        accessories = new List<GameObject>();
        tops = new List<GameObject>();
        pants = new List<GameObject>();
        shoes = new List<GameObject>();
        hair = new List<GameObject>();

        print("lists created"); 
        findObj();
        print("found objects");
        objOff(); 
        saveFile = Application.dataPath + "/save.txt"; 
        saveFile_g = Application.dataPath + "/saveGuitar.txt"; 
        saveFile_d = Application.dataPath + "/saveDrums.txt"; 
        saveFile_p = Application.dataPath + "/savePiano.txt"; 
    
        A_index = 0; 
        T_index = 0; 
        P_index = 0; 
        H_index = 0; 
        S_index = 0; 
        if(isLoadCloth)
        {
            print("load cloth");
            //if the blob is currently active in the hiearchy, then load the blob and clothes
            //will then turn off clothes on inactive blob so that clothes can be loaded on active blob 
            //error says can't load clothes on other blob because only able to on first blob in array
            
            //find objects taht are tagged guitar, piano, and drums from StudioManager code
            // gBlob.findObj();
            Load(); 
        }
        else
        {
            ColorPicker(); 
        }

        // BlobPlayerPrefs(); 
      
    }

    void Update()
    {


        if(isLoadCloth)
        {
            // print("red:");
            // Debug.Log(red); 
        }
        else
        {
            ColorPicker();
        }
       // ColorPicker(); 
        // selectObj(index); 
        // showaObj(index);
       // OpenAccessories();  
        //   for (int i = 0; i < tops.Length; i++)
        // { 
        //     Debug.Log(tops[i]); 
        // }
    }

Transform [] childs ;
    public void findObj()
    {
        //can't use GetComponentsInChildren with GameObject 
     childs = GetComponentsInChildren<Transform>();
       
       for(int i = 0; i < childs.Length; i++)
       {
            Debug.Log("reading children: ", childs[i]);

            if(childs[i].tag == "aObj")
            {
                accessories.Add(childs[i].gameObject);
                print("found accessory");
            }
            if(childs[i].tag == "tObj")
            {
                tops.Add(childs[i].gameObject);
            }
            if(childs[i].tag == "pObj")
            {
                pants.Add(childs[i].gameObject);
            }
            if(childs[i].tag == "sObj")
            {
                shoes.Add(childs[i].gameObject);
            }
            if(childs[i].tag == "hObj")
            {
                hair.Add(childs[i].gameObject);
            }

       }
       
      //  accessories = GameObject.FindGameObjectsWithTag("aObj"); 



        
     //   tops = GameObject.FindGameObjectsWithTag("tObj");
     //   pants = GameObject.FindGameObjectsWithTag("pObj"); 
       // shoes = GameObject.FindGameObjectsWithTag("sObj"); 
        //hair = GameObject.FindGameObjectsWithTag("hObj"); 
    }
    public void objOff()
    {
        for (int i = 0; i < accessories.Count; i++)
        {
            accessories[i].SetActive(false);
            // accessories[i] = objects[i];
            // for each (var item in accessories)
            // {
            //     Console.WriteLine(item); 
            // }
        }
      
        for (int i = 0; i < tops.Count; i++)
        {
            tops[i].SetActive(false); 
        }

        for (int i = 0; i < pants.Count; i++)
        {
            pants[i].SetActive(false); 
        }

        for (int i = 0; i < shoes.Count; i++)
        {
            shoes[i].SetActive(false); 
        }

        for (int i = 0; i < hair.Count; i++)
        {
            hair[i].SetActive(false); 
        }
        //the last object it ends on is the last piece of hair 
       
    }

    void closeObjs(List<GameObject> objs)
    {
        foreach(var o in objs)
        {
            o.SetActive(false);
        }
    }
    void openObjs(List<GameObject> obs)
    {
        foreach(var o in obs)
        {
            o.SetActive(true); 
        }
    }

    public void Next(int whicharray)
    {

        switch(whicharray)
        {
            case 0:
                A_index++;
                if (A_index >= accessories.Count)
                {
                    A_index = 0;
                }
                    
                closeObjs(accessories);
                accessories[A_index].SetActive(true); 
                PlayerPrefs.SetInt("a_index", A_index);
            break;
            
            case 1:
                T_index++;
                if (T_index >= tops.Count)
                {
                    T_index = 0;
                }
                    
                closeObjs(tops);
                tops[T_index].SetActive(true); 
                PlayerPrefs.SetInt("t_index", T_index);
            break;
            
            case 2:
                P_index++;
                if (P_index >= pants.Count)
                {
                    P_index = 0;
                }
                    
                closeObjs(pants);
                pants[P_index].SetActive(true);
                PlayerPrefs.SetInt("p_index", P_index); 
            break;

            case 3:
                H_index++;
                if (H_index >= hair.Count)
                {
                    H_index = 0;
                }
                    
                closeObjs(hair);
                hair[H_index].SetActive(true); 
                PlayerPrefs.SetInt("h_index", H_index);
            break;

            case 4:
                S_index++;
                if (S_index >= shoes.Count)
                {
                    S_index = 0;
                }
                    
                closeObjs(shoes);
                shoes[S_index].SetActive(true); 
                PlayerPrefs.SetInt("s_index", S_index);
            break;
        }
        
    }

    public void Previous(int whicharray)
    {
        switch(whicharray)
        {
            case 0:
                A_index--;
                if (A_index < 0)
                {
                    A_index = accessories.Count - 1;
                }
                    
                closeObjs(accessories);
                accessories[A_index].SetActive(true); 
            break;

            case 1:
                T_index--;
                if (T_index < 0)
                {
                    T_index = tops.Count - 1;
                }
                    
                closeObjs(tops);
                tops[T_index].SetActive(true); 
            break;
            
            case 2:
                P_index--;
                if (P_index < 0)
                {
                    P_index = pants.Count - 1;
                }
                    
                closeObjs(pants);
                pants[P_index].SetActive(true); 
            break;

            case 3:
                H_index--;
                if (H_index < 0)
                {
                    H_index = hair.Count - 1;
                }
                    
                closeObjs(hair);
                hair[H_index].SetActive(true); 
            break;

            case 4:
                S_index--;
                if (S_index < 0)
                {
                    S_index = shoes.Count - 1;
                }
                    
                closeObjs(shoes);
                shoes[S_index].SetActive(true); 
            break;
        }
       
    }

    public void BlobPlayerPrefs()
    {
        if(PlayerPrefs.HasKey("a_index"))
        {
            A_index = PlayerPrefs.GetInt("a_index");
            accessories[A_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("a_index", -1);
        }

        if(PlayerPrefs.HasKey("t_index"))
        {
            T_index = PlayerPrefs.GetInt("t_index");
            tops[T_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("t_index", -1);
        }

        if(PlayerPrefs.HasKey("p_index"))
        {
            P_index = PlayerPrefs.GetInt("p_index");
            pants[P_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("p_index", -1);
        }

        if(PlayerPrefs.HasKey("h_index"))
        {
            H_index = PlayerPrefs.GetInt("h_index");
            hair[H_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("h_index", -1);
        }

        if(PlayerPrefs.HasKey("s_index"))
        {
            S_index = PlayerPrefs.GetInt("s_index");
            shoes[S_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("s_index", -1);
        }
    }

    //reference WAR dd Flexible Color Picker video 
    public void ColorPicker()
    {
        
        if(fcp!=null)
        {
            material.color = fcp.color;

            PlayerPrefs.SetInt("red", ((Color32)material.color).r);
            PlayerPrefs.SetInt("blue", ((Color32)material.color).b);
            PlayerPrefs.SetInt("green", ((Color32)material.color).g);


            if (material.color == null)
            {
                material.color = Color.white;
            }

            // Debug.Log((byte)((Color32)material.color).r);
        }
        red = (byte)((Color32)material.color).r; 
        green = (byte)((Color32)material.color).g; 
        blue = (byte)((Color32)material.color).b; 

        // print("red:");
        // Debug.Log(red); 
        // Debug.Log(green); 
        // Debug.Log(blue); 

    }
    
    //reference Code Monkey Save and Load video
    public void Save()
    {
        //save all assets and skin color 
        SaveObject saveBlob = new SaveObject()
        {
            A_index = A_index,
            T_index = T_index,
            P_index = P_index,
            H_index = H_index,
            S_index = S_index,

            red = red,
            green = green,
            blue = blue
        };
        string json =JsonUtility.ToJson(saveBlob); 
        File.WriteAllText(saveFile,json);
        File.WriteAllText(saveFile_g, json);
        File.WriteAllText(saveFile_d, json);  
        File.WriteAllText(saveFile_p, json);
        
        string saveString = File.ReadAllText(saveFile); 
        Debug.Log(saveString); 
    }

    public void Load() 
    {
        //reference Code Monkey Save and Load video 
        if (File.Exists(saveFile))
        {
            string saveString = File.ReadAllText(saveFile); 
            Debug.Log(saveString); 

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString); 

            //for when user is in scene 2 and wants to load the last saved fit
           // closeObjs(accessories);
            closeObjs(tops);
            closeObjs(pants);
            closeObjs(hair);
            closeObjs(shoes);

            A_index = saveObject.A_index;
            T_index = saveObject.T_index; 
            P_index = saveObject.P_index;
            H_index = saveObject.H_index;  
            S_index = saveObject.S_index; 

            accessories[A_index].SetActive(true); 
            tops[T_index].SetActive(true); 
            pants[P_index].SetActive(true);
            hair[H_index].SetActive(true);
            shoes[S_index].SetActive(true);
            // print(A_index);
            // print(T_index);
            // print(P_index);
            // print(H_index);
            // print(S_index);

            red = saveObject.red; 
            green = saveObject.green; 
            blue = saveObject.blue;
            // // print(red);
            // // print(green);
            // // print (blue);

            tempColor.r = red/255f;
            tempColor.g = green/255f;
            tempColor.b = blue/255f; 

            print("temp:");
            Debug.Log(tempColor);
            // // GetComponent<MeshRenderer>().material.color = tempColor;
            material.color = tempColor;
            print("material:");
            Debug.Log(material.color);
            print("fcp:");
            Debug.Log((float)((Color32)fcp.color).r);
            Debug.Log((float)((Color32)fcp.color).g);
            Debug.Log((float)((Color32)fcp.color).b);

            //Debug: when fcp.color is set to the color saved, it outputs rgba(255,255,255,255)
            fcp.color = material.color; 
            print("set fcp from material");
            Debug.Log(fcp.color);

            PlayerPrefs.SetFloat("red", (float)((Color32)fcp.color).r);
            PlayerPrefs.SetFloat("blue", (float)((Color32)fcp.color).b);
            PlayerPrefs.SetFloat("green", (float)((Color32)fcp.color).g);

            // Debug.Log(red);
            // Debug.Log((float)((Color32)fcp.color).r);
            // Debug.Log((float)((Color32)fcp.color).g);
            // Debug.Log((float)((Color32)fcp.color).b);

        }

        if (File.Exists(saveFile_d) && tag == "drums")
        {
            string saveString = File.ReadAllText(saveFile_d); 
            Debug.Log(saveString); 

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString); 

            //for when user is in scene 2 and wants to load the last saved fit
          //  closeObjs(accessories);
            closeObjs(tops);
            closeObjs(pants);
            closeObjs(hair);
            closeObjs(shoes);

            A_index = saveObject.A_index;
            T_index = saveObject.T_index; 
            P_index = saveObject.P_index;
            H_index = saveObject.H_index;  
            S_index = saveObject.S_index; 

            accessories[A_index].SetActive(true); 
            tops[T_index].SetActive(true); 
            pants[P_index].SetActive(true);
            hair[H_index].SetActive(true);
            shoes[S_index].SetActive(true);
            // print(A_index);
            // print(T_index);
            // print(P_index);
            // print(H_index);
            // print(S_index);

            red = saveObject.red; 
            green = saveObject.green; 
            blue = saveObject.blue;
            // // print(red);
            // // print(green);
            // // print (blue);

            tempColor.r = red/255f;
            tempColor.g = green/255f;
            tempColor.b = blue/255f; 

            print("temp:");
            Debug.Log(tempColor);
            // // GetComponent<MeshRenderer>().material.color = tempColor;
            material.color = tempColor;
            print("material:");
            Debug.Log(material.color);
            print("fcp:");
            Debug.Log((float)((Color32)fcp.color).r);
            Debug.Log((float)((Color32)fcp.color).g);
            Debug.Log((float)((Color32)fcp.color).b);

            //Debug: when fcp.color is set to the color saved, it outputs rgba(255,255,255,255)
            fcp.color = material.color; 
            print("set fcp from material");
            Debug.Log(fcp.color);

            PlayerPrefs.SetFloat("red", (float)((Color32)fcp.color).r);
            PlayerPrefs.SetFloat("blue", (float)((Color32)fcp.color).b);
            PlayerPrefs.SetFloat("green", (float)((Color32)fcp.color).g);

            // Debug.Log(red);
            // Debug.Log((float)((Color32)fcp.color).r);
            // Debug.Log((float)((Color32)fcp.color).g);
            // Debug.Log((float)((Color32)fcp.color).b);

        }

        if (File.Exists(saveFile_g) && tag == "guitar")
        {
            string saveString = File.ReadAllText(saveFile_g); 
            Debug.Log(saveString); 

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString); 

            //for when user is in scene 2 and wants to load the last saved fit
          //  closeObjs(accessories);
            closeObjs(tops);
            closeObjs(pants);
            closeObjs(hair);
            closeObjs(shoes);

            A_index = saveObject.A_index;
            T_index = saveObject.T_index; 
            P_index = saveObject.P_index;
            H_index = saveObject.H_index;  
            S_index = saveObject.S_index; 

            accessories[A_index].SetActive(true); 
            tops[T_index].SetActive(true); 
            pants[P_index].SetActive(true);
            hair[H_index].SetActive(true);
            shoes[S_index].SetActive(true);
            // print(A_index);
            // print(T_index);
            // print(P_index);
            // print(H_index);
            // print(S_index);

            red = saveObject.red; 
            green = saveObject.green; 
            blue = saveObject.blue;
            // // print(red);
            // // print(green);
            // // print (blue);

            tempColor.r = red/255f;
            tempColor.g = green/255f;
            tempColor.b = blue/255f; 

            print("temp:");
            Debug.Log(tempColor);
            // // GetComponent<MeshRenderer>().material.color = tempColor;
            material.color = tempColor;
            print("material:");
            Debug.Log(material.color);
            print("fcp:");
            Debug.Log((float)((Color32)fcp.color).r);
            Debug.Log((float)((Color32)fcp.color).g);
            Debug.Log((float)((Color32)fcp.color).b);

            //Debug: when fcp.color is set to the color saved, it outputs rgba(255,255,255,255)
            fcp.color = material.color; 
            print("set fcp from material");
            Debug.Log(fcp.color);

            PlayerPrefs.SetFloat("red", (float)((Color32)fcp.color).r);
            PlayerPrefs.SetFloat("blue", (float)((Color32)fcp.color).b);
            PlayerPrefs.SetFloat("green", (float)((Color32)fcp.color).g);

            // Debug.Log(red);
            // Debug.Log((float)((Color32)fcp.color).r);
            // Debug.Log((float)((Color32)fcp.color).g);
            // Debug.Log((float)((Color32)fcp.color).b);

        }

        // if (File.Exists(saveFile_p) && tag == "piano")
        // {
        //     string saveString = File.ReadAllText(saveFile_p); 
        //     Debug.Log(saveString); 

        //     SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString); 

        //     //for when user is in scene 2 and wants to load the last saved fit
        //     closeObjs(accessories);
        //     closeObjs(tops);
        //     closeObjs(pants);
        //     closeObjs(hair);
        //     closeObjs(shoes);

        //     A_index = saveObject.A_index;
        //     T_index = saveObject.T_index; 
        //     P_index = saveObject.P_index;
        //     H_index = saveObject.H_index;  
        //     S_index = saveObject.S_index; 

        //     accessories[A_index].SetActive(true); 
        //     tops[T_index].SetActive(true); 
        //     pants[P_index].SetActive(true);
        //     hair[H_index].SetActive(true);
        //     shoes[S_index].SetActive(true);
        //     // print(A_index);
        //     // print(T_index);
        //     // print(P_index);
        //     // print(H_index);
        //     // print(S_index);

        //     red = saveObject.red; 
        //     green = saveObject.green; 
        //     blue = saveObject.blue;
        //     // // print(red);
        //     // // print(green);
        //     // // print (blue);

        //     tempColor.r = red/255f;
        //     tempColor.g = green/255f;
        //     tempColor.b = blue/255f; 

        //     print("temp:");
        //     Debug.Log(tempColor);
        //     // // GetComponent<MeshRenderer>().material.color = tempColor;
        //     material.color = tempColor;
        //     print("material:");
        //     Debug.Log(material.color);
        //     print("fcp:");
        //     Debug.Log((float)((Color32)fcp.color).r);
        //     Debug.Log((float)((Color32)fcp.color).g);
        //     Debug.Log((float)((Color32)fcp.color).b);

        //     //Debug: when fcp.color is set to the color saved, it outputs rgba(255,255,255,255)
        //     fcp.color = material.color; 
        //     print("set fcp from material");
        //     Debug.Log(fcp.color);

        //     PlayerPrefs.SetFloat("red", (float)((Color32)fcp.color).r);
        //     PlayerPrefs.SetFloat("blue", (float)((Color32)fcp.color).b);
        //     PlayerPrefs.SetFloat("green", (float)((Color32)fcp.color).g);

        //     // Debug.Log(red);
        //     // Debug.Log((float)((Color32)fcp.color).r);
        //     // Debug.Log((float)((Color32)fcp.color).g);
        //     // Debug.Log((float)((Color32)fcp.color).b);

        // }
        // SaveObject.SetInt(SaveObject.A_index);
        // Debug.Log(A_index); 

        // reference Destined to Learn Reading JSON file 
        // public BlobList myBlobList = new BlobList(); 
        // myBlobList = JsonUtility.FromJson<BlobList>(saveJson.text);

    }    

    void destroyObj()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject); 
            return; 
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public class SaveObject
    {
        public int A_index,T_index,P_index,H_index,S_index = -1; 
        public float red, green, blue; 
    }
    
    //Destined to Learn
    public class BlobList
    {
        public SaveObject[] blob; 
    }
}

