using UnityEngine;

public class Player : MonoBehaviour
{
    public Observer<int> Health = new Observer<int>(100);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health.Invoke();

        // exemple using implicit operator
        int exemple1 = Health.Value;
        int exemple2 = Health; // ...implicit operator
        Debug.Log(Equals(exemple1, exemple2));
        Debug.Log(Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Health.Value += 10;
            Debug.Log("+10 health");
        }
    }
}
