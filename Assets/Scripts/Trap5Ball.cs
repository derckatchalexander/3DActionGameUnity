using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public float swingSpeed = 2f; // Скорость раскачивания маятника
    public float hitForce = 10.0f; // Сила удара маятника
    public int damage = 20; // Урон, наносимый маятником
    public float corner = 5f;

    private Vector3 initialPosition; // Начальная позиция маятника
    private Vector3 swingDirection; // Направление раскачивания маятника
    private bool isSwinging = true; // Флаг, показывающий, раскачивается ли маятник

void Start()
{
    initialPosition = transform.position;
    swingDirection = transform.right; // Направление раскачивания по умолчанию
}
void Update()
{
    if (isSwinging)
    {
        float swingAngle = Mathf.Sin(Time.time * swingSpeed) * corner; // Угол раскачивания
        transform.position = initialPosition + swingDirection * swingAngle; // Обновление позиции маятника
    }
}
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player")) // Проверка, является ли объект игроком
    {
        Vector3 hitDirection = ((other.transform.position - transform.position)*Time.deltaTime).normalized; // Направление удара
        other.gameObject.GetComponent<CharacterController>().Move(hitDirection * hitForce * Time.deltaTime); // Отбрасывание игрока
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage); // Нанесение урона
    }
}
/*public void StartSwinging()
{
    isSwinging = true;
}
public void StopSwinging()
{
    isSwinging = false;
}*/
}