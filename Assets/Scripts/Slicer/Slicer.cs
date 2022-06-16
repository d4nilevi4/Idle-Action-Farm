using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleAfterSlice;
    [SerializeField] private Material _materialAfterSlice;
    [SerializeField] private LayerMask _sliceMask;
    public bool isTouched;

    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, _sliceMask);
            
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                if (objectToBeSliced.TryGetComponent(out Grass grass))
                {
                    if (grass.CanCollect)
                        grass.Collect();            
                    else
                        continue;
                }

                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, _materialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, _materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, _materialAfterSlice);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                upperHullGameobject.transform.localScale = _scaleAfterSlice;
                lowerHullGameobject.transform.localScale = _scaleAfterSlice;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                Destroy(upperHullGameobject, 1f);
                Destroy(lowerHullGameobject, 1f);
            }
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
