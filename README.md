# GlobantEjercicio
Ejercicio Para Globant

Reciba como argumentos: la ruta de archivo de ciudades, la ruta de archivo de viajes
El archivo de ciudades contiene un listado de ciudades y sus conexiones en texto plano de la siguiente forma:
Formato de línea: <ciudad-A>,<ciudad-B>,<tiempo>,<tipo-via>

Ej:
A,B,15,ruta
B,C,20,autopista
C,D,30,calle
A,C,45,avenida
A,D,60,ruta

Donde cada línea indica una conexión entre ciudades (camino, ruta, autopista) con el respectivo tiempo en minutos que se demora en realizar el trayecto.

En el ejemplo anterior, existen vias que conectan A con B,C y D; B con A,C; C con A,B y D; D con A y C.
El archivo de viajes contiene el listado de viajes registrados incluyendo sus pasajeros de la siguente forma:
Formato de línea: <tipo-vehiculo>,<cant-pasajeros>,<ciudad-1>,<ciudad-2>,<ciudad-3>,...,<ciudad-N>

Ej:
micro,29,A,B
taxi,4,A,B
taxi,3,C,D
taxi,2,B,C,D,A
combi,15,B,A

Donde cada línea tiene información de un viaje registrado y las distintas ciudades del recorrido realizado.
El sistema debe procesar las ciudades y los viajes realizados de la siguente forma:
Los trayectos entre ciudades se consideran en ambos sentidos, es decir, como vías de ida y vuelta.
Pueden existir trayectos aislados de otros, trayectos circulares, etc, ya que esto depende los los caminos que unan las ciudades y que estén habilitados para el trànsito comercial.

Los viajes siempre tienen un mìnimo de 2 ciudades a visitar pero no poseen máximo.
Para cada viaje computado se debe verificar su validez de acuerdo al tipo de vehículo y el tipo de vía a transitar. Esto es:

micros no pueden transitar por autopistas ni calles
combis no pueden transitar por calles
taxis tienen libre tránsito.

Luego, se computa el tiempo empleado en el viaje y se lo almacena ordenado por tipo de vehículo
A su vez, se almacena la cantidad de pasajeros y su ciudad destino (esto es, el destino final de su viaje)

Luego de procesada la totalidad de los viajes, se informa por salida estándar lo siguiente:

Minutos en viajes - micro - <cant-total-minutos>
Minutos en viajes - combi - <cant-total-minutos>
Minutos en viajes - taxi - <cant-total-minutos>

Cantidad turistas - <ciudad-1> - <cant-total-pasajeros-con-destino-ciudad-1>
...
Cantidad turistas - <ciudad-N> - <cant-total-pasajeros-con-destino-ciudad-N>

El archivo de viajes puede ser extenso, por lo tanto, se requiere que  la ejecución de los cálculos correspondientes se realice en 2 hilos de procesamiento: la mitad de los viajes será procesada por el hilo 1 y la otra mitad por el hilo 2
Se pide un sistema desarrollado y funcionando que incluya:

polimorfismo

manejo mínimo de hilos

manejo de excepciones

buenas prácticas de programación y diseño
