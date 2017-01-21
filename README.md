# InsideU (Proyecto en Unity3D)

Unas simples guidelines para usar git y poder colaborar en un proyecto de Unity3D. 
**NOTA: Este repositorio es solo para los proyectos de Unity, para cualquier otro tipo de archivos usen el Drive.**

## Scenes

La regla principal: **SOLAMENTE UNA PERSONA TRABAJA EN UNA ESCENA AL MISMO TIEMPO**
Ahora bien si quieres trabajar en una escena en la que alguien mas esta trabjando,
haz tus cambios y guardalos en un prefab. Despues regresa la escena a su estado original `` git reset HEAD nombreDeEscena.unity nombreDeEscena.unity.meta `` y haz tu commit.

## Configuracion

1. Asegurate que cuentas con la misma version de Unity que tu equipo (5.4.1)
2. Habilita los archivos .meta `` Edit -> Project Settings -> Editor -> Version Control -> Mode -> Visible Meta Files ``
3. Habilita la serializacion de Assets `` Edit -> Project Settings -> Editor -> Asset Serialization -> Mode -> Force Text ``
4. Instalar git-lfs (https://git-lfs.github.com) para los archivos pesados (como audios)

## Haciendo commits

1. Antes de hacer un commit asegurate que guardes la escena y el proyecto.
2. Asegurate que guardes un .meta por cada asset.
3. Cierra Unity.
4. Al hacer el commit, indica cuales fueron los cambios (y detallalos), esto sirve para mantener el control de versiones y poder regresar en caso de errores.

## Haciendo pulls

1. Asegurate de cerrar Unity.
2. Haz pull.
3. Abre Unity.
