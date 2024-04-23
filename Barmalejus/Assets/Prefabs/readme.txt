Because you can't save prefabs with references to other scripts from other game objects, 
I'm putting this as a reminder on how to configure crosshair:

1. In Managers object -> CrosshairManager put a reference to crosshair object (it's on camera)
2. Reference CrosshairManager in RayCasting script.