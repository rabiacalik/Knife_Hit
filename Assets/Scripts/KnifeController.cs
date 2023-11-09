using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D _knifeRigitbody;
    private KnifeManager _knifeManager;

    [SerializeField] private float _moveSpead;
    private bool canShoot; //firlatilabilir mi 

    private void Start()
    {
        GetComponentValue();
    }

    private void Update()
    {
        GetInputValues();
    }


    private void FixedUpdate()
    {
        Shoot();
    }

    private void GetInputValues()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _knifeManager.SetKinefeIconDisableColor();
            canShoot = true;
        }
    }

    //yukari yonlu firlama hareketi
    private void Shoot()
    {
        if (canShoot)
        {
            _knifeRigitbody.AddForce(Vector2.up * _moveSpead * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kutuk"))
        {
            _knifeManager.SetActiveKnife();
            canShoot = false;                                       //kutukle etkilesime girince fýrlamaya devam etmemesi icin
            _knifeRigitbody.isKinematic = true;
            transform.SetParent(collision.gameObject.transform);    //bicagi, kutugun child i yapiyoruz
        }

        else if (collision.gameObject.CompareTag("bicak"))
        {
            SceneManager.LoadScene(0);
        }
    }


    // bagladigimiz componentlerin degerlerini aliyoruz
    private void GetComponentValue()
    {
        _knifeRigitbody = GetComponent<Rigidbody2D>();
        _knifeManager = GameObject.FindObjectOfType<KnifeManager>();
    }

}
